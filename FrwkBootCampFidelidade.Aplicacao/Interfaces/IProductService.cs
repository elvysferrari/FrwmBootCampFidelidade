using FrwkBootCampFidelidade.DTO.ProductContext;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetByPromotion(int promotionId);
    }
}
