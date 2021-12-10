using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;

namespace FrwkBootCampFidelidade.Infraestrutura.RansomContext.Repository
{
    public class RansomRepository : BaseRepository<Ransom>, IRansom
    {
        private readonly DBContext _context;

        public RansomRepository(DBContext context): base(context)
        {
            _context = context;
        }
    }
}
