using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Consumers
{
    public class OrderKafkaConsumer : BackgroundService
    {
        private readonly string nomeTopic = "Orders";

        public OrderKafkaConsumer()
        {
            //var config = new ConsumerConfig
            //{
            //    BootstrapServers = "localhost:29092",
            //    GroupId = $"Orders-group-0",
            //    AutoOffsetReset = AutoOffsetReset.Earliest
            //};


            //CancellationTokenSource cts = new CancellationTokenSource();
            //Console.CancelKeyPress += (_, e) =>
            //{
            //    e.Cancel = true;
            //    cts.Cancel();
            //};

            //try
            //{
            //    using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            //    {
            //        consumer.Subscribe(nomeTopic);

            //        try
            //        {
            //            while (true)
            //            {
            //                var cr = consumer.Consume(cts.Token);
            //            }
            //        }
            //        catch (OperationCanceledException)
            //        {
            //            consumer.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exceção: {ex.GetType().FullName} | " +
            //                 $"Mensagem: {ex.Message}");
            //}
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = $"Orders-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(nomeTopic);

                    try
                    {
                        while (true)
                        {
                            var cr = consumer.Consume(cts.Token);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção: {ex.GetType().FullName} | " +
                             $"Mensagem: {ex.Message}");
            }

            return Task.CompletedTask;
        }

            //    return Task.CompletedTask;
            //}

            //private async Task<string> InvokeService(MessageInputModel message)
            //{
            //    using var scope = _serviceProvider.CreateScope();
            //    var OrderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

            //    dynamic response = string.Empty;

            //    switch (message.Method)
            //    {
            //        case MethodConstant.POST:
            //            response = await OrderService.Add(JsonConvert.DeserializeObject<OrderDTO>(message.Content));
            //            break;
            //    }

            //    return JsonConvert.SerializeObject(response);
            //}
        }
}
