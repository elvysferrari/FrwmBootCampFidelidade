using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IPromotionService
    {
        Task<List<PromotionDTO>> GetAll();
        Task<PromotionDTO> GetById(int id);
        Task<List<PromotionDTO>> GetPromotionByDateRange(PromotionRequestDTO promotionRequestDTO);
        Task<List<PromotionDTO>> GetPromotionToday();
    }
}
