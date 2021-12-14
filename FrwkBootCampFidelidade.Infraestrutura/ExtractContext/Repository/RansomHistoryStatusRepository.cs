using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using FrwkBootCampFidelidade.DTO.ExtractContext;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Repository
{
    public class RansomHistoryStatusRepository : BaseRepository<RansomHistoryStatus>, IRansomHistoryStatusRepository
    {
        private readonly DBContext _context;

        public RansomHistoryStatusRepository(DBContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<RansomHistoryStatusDTO>> GetByUserId(int userId)
        {
            var query = from extracts in _context.Extracts
                        join ranson in _context.Ransoms on extracts.RansomId equals ranson.Id
                        join wallet in _context.Wallets on ranson.WalletId equals wallet.Id
                        where userId == wallet.UserId
                        orderby extracts.Date
                        select new RansomHistoryStatusDTO() { Id = extracts.Id };

            return await query.ToListAsync();
        }
        public async Task<List<RansomHistoryStatusDTO>> GetByCPF(string cpf)
        {
            var query = from extracts in _context.Extracts
                        join ranson in _context.Ransoms on extracts.RansomId equals ranson.Id
                        join wallet in _context.Wallets on ranson.WalletId equals wallet.Id
                        where cpf == ranson.CPF
                        orderby extracts.Date
                        select new RansomHistoryStatusDTO() { Id = extracts.Id };

            return await query.ToListAsync();
        }

        //public async Task<List<RansomHistoryStatusDTO>> GetByCPF(string cpf)
        //{
        //    var query = from extracts in _context.Extracts
        //                join orders in _context.Orders on extracts.Id equals orders.Id
        //                where cpf == orders.CPF
        //                orderby extracts.Id
        //                select new RansomHistoryStatusDTO() { Id = extracts.Id };

        //    return await query.ToListAsync();
        //}
    }
}
