using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(IConfiguration configuration)
        {
            var datasource = Environment.GetEnvironmentVariable("MongoDbDatasource");
            var database = Environment.GetEnvironmentVariable("MongoDbDatabase");

            var _client = new MongoClient(datasource);
            var _database = _client.GetDatabase(database);

            Promotions = _database.GetCollection<Promotion>("promotions");

            PromotionContextSeed.SeedData(Promotions);
        }

        public IMongoCollection<Promotion> Promotions { get; }
    }
}
