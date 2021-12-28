using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionStrings:Connection"]);
            var database = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);

            Promotions = database.GetCollection<Promotion>("promotions");
            PromotionItems = database.GetCollection<PromotionItem>("promotionsitem");

            PromotionContextSeed.SeedData(Promotions);
            PromotionItemContextSeed.SeedData(PromotionItems);
        }

        public IMongoCollection<Promotion> Promotions { get; }

        public IMongoCollection<PromotionItem> PromotionItems { get; }
    }
}
