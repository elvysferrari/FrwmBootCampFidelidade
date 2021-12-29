using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces
{
    public interface IPromotionItemRepository
    {
        Task<IEnumerable<PromotionItem>> GetAll();
        Task<PromotionItem> GetById(string id);
        Task<IEnumerable<PromotionItem>> GetPromotionItemsByPromotionId(string promotionId);
        Task<PromotionItem> Add(PromotionItem promotionItem);
        Task<bool> Update(PromotionItem promotionItem);
        Task<bool> RemoveById(string id);
        Task<bool> Remove(PromotionItem promotionItem);
    }
}
