using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces
{
    public interface IPromotionRepository : IBaseRepository<Promotion>
    {
        Task<List<Promotion>> GetPromotionByDateRange(PromotionRequestDTO promotionRequest);
        Task<List<Promotion>> GetPromotionToday();
    }
}
