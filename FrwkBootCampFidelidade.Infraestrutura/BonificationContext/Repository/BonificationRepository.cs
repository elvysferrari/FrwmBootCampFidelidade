using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.DTO.BonificationContext;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Repository
{
    public class BonificationRepository : BaseRepository<Bonification>, IBonificationRepository 
    {
        private readonly DBContext _context;

        public BonificationRepository(DBContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<BonificationDTO>> GetByUserId(int userId)
        {
            var query = from bonifications in _context.Bonifications
                        join orders in _context.Orders on bonifications.Id equals orders.Id
                        where userId == orders.UserId
                        orderby bonifications.Id
                        select new BonificationDTO() { Id = bonifications.Id, scoreQuantity = bonifications.ScoreQuantity, OrderId = orders.Id, UserId = orders.UserId, date = bonifications.Date };

            return await query.ToListAsync();            
        }
        public async Task<List<BonificationDTO>> GetByCPF(string cpf)
        {
            var query = from bonifications in _context.Bonifications
                        join orders in _context.Orders on bonifications.Id equals orders.Id
                        where cpf == orders.CPF
                        orderby bonifications.Id
                        select new BonificationDTO() { Id = bonifications.Id, scoreQuantity = bonifications.ScoreQuantity, OrderId = orders.Id, UserId = orders.UserId, date = bonifications.Date };

            return await query.ToListAsync();
        }
    }
}
