using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;

namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Repository
{
    public class ExtractRepository : BaseRepository<Extract>, IExtract
    {
        private readonly DBContext _context;

        public ExtractRepository(DBContext context): base(context)
        {
            _context = context;
        }
    }
}
