using Confluent.Kafka;
using Confluent.Kafka.Admin;
using FrwkBootCampFidelidade.Aplicacao.Configuration;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.DTO.OrderContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Consumers
{
    public class OrderConsumer : BackgroundService
    {
        private readonly KafkaConfiguration _config;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _topicName;
        private readonly ConsumerConfig _consumerConfig;

        public OrderConsumer(IOptions<KafkaConfiguration> option, IServiceProvider serviceProvider)
        {
            _config = option.Value;
            _serviceProvider = serviceProvider;
            _topicName = "frwkBootcampFidelidadeOrder";

            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _config.Host,
                GroupId = $"{_topicName}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _cancellationTokenSource = new CancellationTokenSource();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var task = Task.Run(() => ProcessQueue(stoppingToken), stoppingToken);

            return task;
        }

        private void ProcessQueue(CancellationToken stoppingToken)
        {
            using (var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build())
            {
                consumer.Subscribe(_topicName);

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(stoppingToken);
 
                            Task.Run(async () => { await InvokeService(consumeResult); }, stoppingToken);
                        }
                        catch (ConsumeException ex)
                        { }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    consumer.Close();
                }
            }
        }

        private async Task<string> InvokeService(ConsumeResult<Ignore, string> message)
        {
            using var scope = _serviceProvider.CreateScope();
            var OrderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

            dynamic response = string.Empty;

            await OrderService.Add(JsonConvert.DeserializeObject<OrderDTO>(message.Message.Value));

            return JsonConvert.SerializeObject(response);
        }
    }
}
