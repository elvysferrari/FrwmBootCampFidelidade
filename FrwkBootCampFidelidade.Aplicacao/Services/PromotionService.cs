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
        private readonly IPromotionRepository _promotionRepository;
        private readonly IPromotionItemService _promotionItemService;

        public PromotionService(IMapper mapper, IPromotionRepository promotionRepository,
            IPromotionItemService promotionItemService)
        {
            _mapper = mapper;
            _promotionRepository = promotionRepository;
            _promotionItemService = promotionItemService;
        }

        private async Task<IEnumerable<PromotionItemDTO>> GetItems(string promotionId)
        {
            return await _promotionItemService.GetPromotionItemsByPromotionId(promotionId);
        }

        public async Task<IEnumerable<PromotionDTO>> GetPromotionByDateRange(PromotionRequestDTO promotionRequestDTO)
        {
            var promotions = await _promotionRepository.GetPromotionByDateRange(promotionRequestDTO);
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);

            foreach (var promotion in promotionsDTO)
            {
                promotion.PromotionItems = await GetItems(promotion.Id);
            }
            
            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetPromotionToday()
        {
            var promotions = await _promotionRepository.GetPromotionToday();
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);

            foreach (var promotion in promotionsDTO)
            {
                promotion.PromotionItems = await GetItems(promotion.Id);
            }

            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetAll()
        {
            var promotions = await _promotionRepository.GetAll();
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);

            foreach (var promotion in promotionsDTO)
            {
                promotion.PromotionItems = await GetItems(promotion.Id);
            }

            return promotionsDTO;
        }

        public async Task<PromotionDTO> GetById(string id)
        {
            var promotion = await _promotionRepository.GetById(id);

            if (promotion == null)
            {
                return null;
            }

            var promotionDTO = _mapper.Map<PromotionDTO>(promotion);
            promotionDTO.PromotionItems = await GetItems(promotion.Id);

            return promotionDTO;
        }

        public async Task<PromotionDTO> Add(PromotionCreateDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            promot.CreatedAt = DateTime.Now;
            promot.UpdatedAt = DateTime.Now;

            promot = await _promotionRepository.Add(promot);
            var promotionDTO = _mapper.Map<PromotionDTO>(promot);
            return promotionDTO;
        }

        public async Task<bool> Update(PromotionUpdateDeleteDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            var promotionOld = await _promotionRepository.GetById(promotion.Id);
            
            if(promotionOld == null)
            {
                return false;
            }

            promot.CreatedAt = promotionOld.CreatedAt;
            promot.UpdatedAt = DateTime.Now;
            return await _promotionRepository.Update(promot);
        }

        public async Task<bool> RemoveById(string id)
        {
            return await _promotionRepository.RemoveById(id);
        }

        public async Task<bool> Remove(PromotionUpdateDeleteDTO promotion)
        {
            var promot = _mapper.Map<Promotion>(promotion);
            return await _promotionRepository.Remove(promot);
        }
    }
}
