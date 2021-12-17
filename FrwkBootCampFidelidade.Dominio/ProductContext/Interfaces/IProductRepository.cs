using FrwkBootCampFidelidade.Dominio.ProductContext.Entities;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Dominio.ProductContext.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByPromotion(string promotionId);
    }
}
