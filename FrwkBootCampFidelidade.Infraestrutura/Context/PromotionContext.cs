using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.Context
{
    public class PromotionContext : IPromotionContext
    {
        public PromotionContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionStrings:Connection"]);
            var database = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);

            Promotions = database.GetCollection<Promotion>(configuration["ConnectionStrings:CollectionName"]);

            PromotionContextSeed.SeedData(Promotions);
        }

        public IMongoCollection<Promotion> Promotions { get; }
    }
}
