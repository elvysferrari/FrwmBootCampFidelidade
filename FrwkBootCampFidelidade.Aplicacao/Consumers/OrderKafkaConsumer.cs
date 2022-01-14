using Confluent.Kafka;
using FrwkBootCampFidelidade.Aplicacao.Configuration;
using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.DTO.OrderContext;
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
    public class OrderKafkaConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderKafkaConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:290092",
                //  GroupId = $
            };
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: DomainConstant.ORDER, autoAck: false, consumer: consumer);

            consumer.Received += async (model, ea) =>
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

                    var replyMessage = await InvokeService(message);

                    response = replyMessage;
                }
                catch (Exception e)
                {
                    response = e.Message;
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

        private async Task<string> InvokeService(MessageInputModel message)
        {
            using var scope = _serviceProvider.CreateScope();
            var OrderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

            dynamic response = string.Empty;

            switch (message.Method)
            {
                case MethodConstant.POST:
                    response = await OrderService.Add(JsonConvert.DeserializeObject<OrderDTO>(message.Content));
                    break;
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
