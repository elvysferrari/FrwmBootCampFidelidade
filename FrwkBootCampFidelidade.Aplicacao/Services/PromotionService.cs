using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IMapper _mapper;
        private readonly IPromotionRepository _promotion;
        private readonly IProductService _productService;

        public PromotionService(IMapper mapper, IPromotionRepository promotion, IProductService productService)
        {
            _mapper = mapper;
            _promotion = promotion;
            _productService = productService;
        }

        private IEnumerable<PromotionDTO> GetProducts(IEnumerable<Promotion> promotions)
        {
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);
            foreach (var promotion in promotionsDTO)
            {
                promotion.Products = _productService.GetByPromotion(promotion.Id);
            }
            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetPromotionByDateRange(PromotionRequestDTO promotionRequestDTO)
        {
            var promotions = await _promotion.GetPromotionByDateRange(promotionRequestDTO);
            var promotionsDTO = GetProducts(promotions);
            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetPromotionToday()
        {
            var promotions = await _promotion.GetPromotionToday();
            var promotionsDTO = GetProducts(promotions);
            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetAll()
        {
            var promotions = _promotion.GetAll().ToList();
            var promotionsDTO = GetProducts(promotions);
            return promotionsDTO;
        }

        public async Task<PromotionDTO> GetById(int id)
        {
            var promotion = await _promotion.GetById(id);
            
            if(promotion == null)
            {
                return null;
            }

            var promotionDTO = _mapper.Map<PromotionDTO>(promotion);
            promotionDTO.Products = _productService.GetByPromotion(promotion.Id);
            return promotionDTO;
        }
    }
}
