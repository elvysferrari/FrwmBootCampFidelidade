using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Bonification.API.Options;
using FrwkBootCampFidelidade.Core.Constants;
using FrwkBootCampFidelidade.Core.RabbitMq;
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

namespace FrwkBootCampFidelidade.Bonification.API.Consumer
{
    public class BonificationConsumer : BackgroundService
    {
        private readonly BonificationRabbitMqConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public BonificationConsumer(IOptions<BonificationRabbitMqConfiguration> option, IServiceProvider serviceProvider)
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
                        queue: DomainConstant.QUEUE_BONIFICATION,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: DomainConstant.QUEUE_BONIFICATION, autoAck: false, consumer: consumer);

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
                var bonificationService = scope.ServiceProvider.GetRequiredService<IBonificationService>();

                dynamic response = string.Empty;

                switch (message.Method)
                {
                    case MethodConstant.GET:
                        response = bonificationService.GetByCPF(message.Content);
                        break;
                    default:
                        break;
                }

                return JsonConvert.SerializeObject(response);
            }
        }
    }
}

