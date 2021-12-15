using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Repository
{
    public class PromotionRepository : BaseRepository<Promotion>, IPromotionRepository
    {
        private readonly DBContext _context;

        public PromotionRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promotion>> GetPromotionByDateRange(PromotionRequestDTO promotionRequest)
        {
            return await _context.Promotions.Where(x => 
                                        x.StartDate >= promotionRequest.StartDate &&
                                        x.EndDate <= promotionRequest.EndDate)
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Promotion>> GetPromotionToday()
        {
            return await _context.Promotions.Where(x => 
                                        x.StartDate >= DateTime.Now &&
                                        x.EndDate <= DateTime.Now)
                                        .AsNoTracking()
                                        .ToListAsync();
        }
    }
}
