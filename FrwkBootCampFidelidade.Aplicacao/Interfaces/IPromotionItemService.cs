using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IPromotionItemService
    {
        Task<IEnumerable<PromotionItemDTO>> GetAll();
        Task<PromotionItemDTO> GetById(string id);
        Task<IEnumerable<PromotionItemDTO>> GetPromotionItemsByPromotionId(string promotionId);
        Task<PromotionItemDTO> Add(PromotionItemDTO promotionItem);
        Task<bool> Update(PromotionItemDTO promotionItem);
        Task<bool> RemoveById(string id);
        Task<bool> Remove(PromotionItemDTO promotionItem);
    }
}
