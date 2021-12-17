using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionDTO>> GetAll();
        Task<PromotionDTO> GetById(string id);
        Task<IEnumerable<PromotionDTO>> GetPromotionByDateRange(PromotionRequestDTO promotionRequest);
        Task<IEnumerable<PromotionDTO>> GetPromotionToday();
        Task<PromotionDTO> Add(PromotionCreateDTO promotion);
        Task<bool> Update(PromotionUpdateDeleteDTO promotion);
        Task<bool> RemoveById(string id);
        Task<bool> Remove(PromotionUpdateDeleteDTO promotion);
    }
}
