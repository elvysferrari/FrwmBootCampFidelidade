using FrwkBootCampFidelidade.Aplicacao.Configuration;
using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.DTO.ExtractContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Consumers
{
    public class ExtractConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMqConfiguration _config;

        public ExtractConsumer(IServiceProvider serviceProvider, IOptions<RabbitMqConfiguration> options)
        {
            _serviceProvider = serviceProvider;
            _config = options.Value;

            var factory = new ConnectionFactory
            {
                HostName = _config.Host
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                        queue: DomainConstant.EXTRACT,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            _channel.BasicQos(0, 1, false);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: DomainConstant.EXTRACT, autoAck: false, consumer: consumer);

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
            using var scope = _serviceProvider.CreateScope();
            var extractService = scope.ServiceProvider.GetRequiredService<IExtractService>();

            dynamic response = string.Empty;

            switch (message.Method)
            {
                case MethodConstant.GETBYCPF:
                    response = extractService.GetByCPF(message.Content);
                    break;
                case MethodConstant.GETBYUSERID:
                    response = extractService.GetByUserId(int.Parse(message.Content));
                    break;
                case MethodConstant.GETSUMMARYPOINTSBYUSERID:
                    response = extractService.GetSummaryPoints(int.Parse(message.Content));
                    break;
                case MethodConstant.INSERT:
                    response = extractService.Add(JsonConvert.DeserializeObject<RansomHistoryStatusDTO>(message.Content));
                    break;
                default:
                    break;
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}

