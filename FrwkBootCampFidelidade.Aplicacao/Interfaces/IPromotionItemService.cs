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
        Task<PromotionItemDTO> Add(PromotionItemCreateDTO promotionItem);
        Task<bool> Update(PromotionItemUpdateDeleteDTO promotionItem);
        Task<bool> RemoveById(string id);
        Task<bool> Remove(PromotionItemUpdateDeleteDTO promotionItem);
    }
}
