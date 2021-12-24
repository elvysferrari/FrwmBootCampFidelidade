using FrwkBootCampFidelidade.Extract.API.Options;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Extract.API.Consumer
{
    public class ExtractConsumer : BackgroundService
    {
        private readonly ExtractRabbitMqConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
