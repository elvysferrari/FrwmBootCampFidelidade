using FrwkBootCampFidelidade.DTO.ProductContext;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetByPromotion(int promotionId);
    }
}
