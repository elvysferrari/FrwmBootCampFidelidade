using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;

namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Repository
{
    public class RansomHistoryStatus : BaseRepository<Dominio.ExtractContext.Entities.RansomHistoryStatus>, IRansomHistoryStatus
    {
        private readonly DBContext _context;

        public RansomHistoryStatus(DBContext context): base(context)
        {
            _context = context;
        }
    }
}
