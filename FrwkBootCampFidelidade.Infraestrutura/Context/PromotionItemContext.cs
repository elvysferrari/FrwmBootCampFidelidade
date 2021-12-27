using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.Context
{
    //public class PromotionItemContext : IPromotionItemContext
    //{
    //    public PromotionItemContext(IConfiguration configuration)
    //    {
    //        var client = new MongoClient(configuration["ConnectionStrings:Connection"]);
    //        var database = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);

    //        PromotionItems = database.GetCollection<PromotionItem>(configuration["ConnectionStrings:CollectionName"]);

    //        PromotionItemContextSeed.SeedData(PromotionItems);
    //    }

    //    public IMongoCollection<PromotionItem> PromotionItems { get; }
    //}
}
