using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.ProductContext.Entities;
using FrwkBootCampFidelidade.DTO.ProductContext;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetById(long productId)
        {
            var products = new Product
            {
                Id = 1,
                Name = "Nome",
                Description = "Descrição",
                Price = 10
            };

            var productDTO = _mapper.Map<ProductDTO>(products);
            return productDTO;
        }
    }
}
