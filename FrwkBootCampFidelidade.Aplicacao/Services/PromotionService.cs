using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using System;
using System.Collections.Generic;
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
            var promotions = await _promotion.GetAll();
            var promotionsDTO = GetProducts(promotions);
            return promotionsDTO;
        }

        public async Task<PromotionDTO> GetById(string id)
        {
            var promotion = await _promotion.GetById(id);

            if (promotion == null)
            {
                return null;
            }

            var promotionDTO = _mapper.Map<PromotionDTO>(promotion);
            promotionDTO.Products = _productService.GetByPromotion(promotion.Id);
            return promotionDTO;
        }

        public async Task<PromotionDTO> Add(PromotionCreateDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            promot.CreatedAt = DateTime.Now;
            promot.UpdatedAt = DateTime.Now;

            promot = await _promotion.Add(promot);
            var promotionDTO = _mapper.Map<PromotionDTO>(promot);
            return promotionDTO;
        }

        public async Task<bool> Update(PromotionUpdateDeleteDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            var promotionOld = await _promotion.GetById(promotion.Id);
            
            if(promotionOld == null)
            {
                return false;
            }

            promot.CreatedAt = promotionOld.CreatedAt;
            promot.UpdatedAt = DateTime.Now;
            return await _promotion.Update(promot);
        }

        public async Task<bool> RemoveById(string id)
        {
            return await _promotion.RemoveById(id);
        }

        public async Task<bool> Remove(PromotionUpdateDeleteDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            return await _promotion.Remove(promot);
        }
    }
}
