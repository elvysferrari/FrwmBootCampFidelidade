using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.DTO.RansomContext;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Infraestrutura.RansomContext.Repository
{
    public class RansomRepository : BaseRepository<Ransom>, IRansomRepository
    {
        private readonly DBContext _context;

        public RansomRepository(DBContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<RansomDTO>> GetAll()
        {
            return await _context.Set<RansomDTO>().ToListAsync();
        }

        public async Task<List<RansomDTO>> GetListByCPF(string cpf)
        {
            var query = from ransoms in _context.Ransoms
                        where cpf == ransoms.CPF
                        orderby ransoms.Id
                        select new RansomDTO() { Id = ransoms.Id, WalletId = ransoms.WalletId, Amount = ransoms.Amount, 
                            Date = ransoms.Date, Beneficiary = ransoms.Beneficiary, Cpf = ransoms.CPF, PixKeyType = ransoms.PixKeyType,
                            PixKey = ransoms.PixKey, BankNumber = ransoms.BankNumber, Agency = ransoms.Agency, BankAccountNumber = ransoms.BankAccountNumber,
                            Operation = ransoms.Operation};

            return await query.ToListAsync();
        }
    }
}
