using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionDTO>> GetAll();
        Task<PromotionDTO> GetById(int id);
        Task<IEnumerable<PromotionDTO>> GetPromotionByDateRange(PromotionRequestDTO promotionRequestDTO);
        Task<IEnumerable<PromotionDTO>> GetPromotionToday();
    }
}
