using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;

namespace FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Repository
{
    public class BonificationRepository : BaseRepository<Bonification>, IBonification 
    {
        private readonly DBContext _context;

        public BonificationRepository(DBContext context): base(context)
        {
            _context = context;
        }
    }
}
