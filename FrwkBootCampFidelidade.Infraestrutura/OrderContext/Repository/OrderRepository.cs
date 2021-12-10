using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using FrwkBootCampFidelidade.Dominio.OrderContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Base.Repository;
using FrwkBootCampFidelidade.Infraestrutura.Context;

namespace FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrder 
    {
        private readonly DBContext _context;

        public OrderRepository(DBContext context): base(context)
        {
            _context = context;
        }
    }
}
