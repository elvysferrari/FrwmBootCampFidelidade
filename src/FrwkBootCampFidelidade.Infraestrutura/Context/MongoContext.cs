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
            var Datasource = Environment.GetEnvironmentVariable("Datasource");
            var Database = Environment.GetEnvironmentVariable("Database");
            var DbUser = Environment.GetEnvironmentVariable("DbUser");
            var Password = Environment.GetEnvironmentVariable("Password");

            var client = new MongoClient(Datasource);
            var database = client.GetDatabase(Database);

            Promotions = database.GetCollection<Promotion>("promotions");
            PromotionItems = database.GetCollection<PromotionItem>("promotionsitem");

            PromotionContextSeed.SeedData(Promotions);
            //PromotionItemContextSeed.SeedData(PromotionItems);
        }

        public IMongoCollection<Promotion> Promotions { get; }

        public IMongoCollection<PromotionItem> PromotionItems { get; }
    }
}
