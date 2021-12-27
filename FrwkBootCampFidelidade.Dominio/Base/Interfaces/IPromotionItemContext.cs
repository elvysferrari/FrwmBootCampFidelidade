using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using MongoDB.Driver;

namespace FrwkBootCampFidelidade.Dominio.Base.Interfaces
{
    public interface IPromotionItemContext
    {
        IMongoCollection<PromotionItem> PromotionItems { get; }
    }
}
