using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using MongoDB.Driver;

namespace FrwkBootCampFidelidade.Dominio.Base.Interfaces
{
    public interface IPromotionContext
    {
        IMongoCollection<Promotion> Promotions { get; } 
    }
}
