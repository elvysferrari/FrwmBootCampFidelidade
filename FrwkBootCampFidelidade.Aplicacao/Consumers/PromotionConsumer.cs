using FrwkBootCampFidelidade.Aplicacao.Configuration;
using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Consumers
{
    public class PromotionConsumer : BackgroundService
    {
        private readonly RabbitMqConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public PromotionConsumer(IOptions<RabbitMqConfiguration> option, IServiceProvider serviceProvider)
        {
            _config = option.Value;
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = _config.Host
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                        queue: DomainConstant.PROMOTION,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: DomainConstant.PROMOTION, autoAck: false, consumer: consumer);

            consumer.Received += (model, ea) =>
            {
                string response = null;

                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    var contentArray = ea.Body.ToArray();
                    var incommingMessage = Encoding.UTF8.GetString(contentArray);
                    var message = JsonConvert.DeserializeObject<MessageInputModel>(incommingMessage);

                    var replyMessage = InvokeService(message);

                    response = replyMessage;
                }
                catch (Exception e)
                {
                    response = "";
                }
                finally
                {
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    _channel.BasicPublish(exchange: "", routingKey: props.ReplyTo,
                      basicProperties: replyProps, body: responseBytes);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag,
                      multiple: false);
                }
            };

            return Task.CompletedTask;
        }

        private string InvokeService(MessageInputModel message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var promotionService = scope.ServiceProvider.GetRequiredService<IPromotionService>();

                dynamic response = string.Empty;

                switch (message.Method)
                {
                    case MethodConstant.POST:
                        var promotionCreateDTO = JsonConvert.DeserializeObject<PromotionCreateDTO>(message.Content);
                        response = promotionService.Add(promotionCreateDTO);
                        break;
                    case MethodConstant.GET:
                        response = promotionService.GetAll();
                        break;
                    case MethodConstant.GETBYID:
                        var id = JsonConvert.DeserializeObject<string>(message.Content);
                        response = promotionService.GetById(id);
                        break;
                    case MethodConstant.GETPROMOTIONTODAY:
                        response = promotionService.GetPromotionToday();
                        break;
                    case MethodConstant.GETPROMOTIONBYDATERANGE:
                        var promotionRequestDTO = JsonConvert.DeserializeObject<PromotionRequestDTO>(message.Content);
                        response = promotionService.GetPromotionByDateRange(promotionRequestDTO);
                        break;
                    case MethodConstant.DELETE:
                        var promotionUpdateDTO = JsonConvert.DeserializeObject<PromotionUpdateDeleteDTO>(message.Content);
                        response = promotionService.Remove(promotionUpdateDTO);
                        break;
                    case MethodConstant.REMOVEBYID:
                        var id_r = JsonConvert.DeserializeObject<string>(message.Content);
                        response = promotionService.RemoveById(id_r);
                        break;
                    case MethodConstant.PUT:
                        var promotionDeleteDTO = JsonConvert.DeserializeObject<PromotionUpdateDeleteDTO>(message.Content);
                        response = promotionService.Update(promotionDeleteDTO);
                        break;
                    default:
                        break;
                }

                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
