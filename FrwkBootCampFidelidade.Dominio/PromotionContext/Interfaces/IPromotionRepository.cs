using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAll();
        Task<Promotion> GetById(string id);
        Task<IEnumerable<Promotion>> GetPromotionByDateRange(PromotionRequestDTO promotionRequest);
        Task<IEnumerable<Promotion>> GetPromotionToday();
        Task<Promotion> Add(Promotion promotion);
        Task<bool> Update(Promotion promotion);
        Task<bool> RemoveById(string id);
        Task<bool> Remove(Promotion promotion);
    }
}
