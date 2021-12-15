using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.ProductContext.Interfaces;
using FrwkBootCampFidelidade.DTO.ProductContext;
using System.Collections.Generic;
using System.Linq;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public ProductService(IMapper mapper, IProductRepository product)
        {
            _mapper = mapper;
            _product = product;
        }

        public IEnumerable<ProductDTO> GetByPromotion(int promotionId)
        {
           var products = _product.GetByPromotion(promotionId);
           var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
           return productDTO;
        }
    }
}
