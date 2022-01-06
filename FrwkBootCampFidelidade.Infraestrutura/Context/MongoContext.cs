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
        public MongoContext(string datasource = null, string dataBase = null)
        {
            var Datasource = string.IsNullOrEmpty(datasource) ? Environment.GetEnvironmentVariable("Datasource") : datasource;
            var Database = string.IsNullOrEmpty(dataBase) ? Environment.GetEnvironmentVariable("Database") : dataBase;
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
