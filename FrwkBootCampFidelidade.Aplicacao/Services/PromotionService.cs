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

        public async Task<IEnumerable<PromotionDTO>> GetPromotionByDateRange(PromotionDTO promotionRequest)
        {
            var promotion = _mapper.Map<Promotion>(promotionRequest);
            var promotions = await _promotionRepository.GetPromotionByDateRange(promotion);
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);

            foreach (var pro in promotionsDTO)
            {
                pro.PromotionItems = await GetItems(pro.Id);
            }
            
            return promotionsDTO;
        }

        public async Task<IEnumerable<PromotionDTO>> GetPromotionToday(PromotionDTO promotionRequest)
        {
            var promotion = _mapper.Map<Promotion>(promotionRequest);
            var promotions = await _promotionRepository.GetPromotionToday(promotion);
            var promotionsDTO = _mapper.Map<IEnumerable<PromotionDTO>>(promotions);

            foreach (var pro in promotionsDTO)
            {
                pro.PromotionItems = await GetItems(pro.Id);
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

        public async Task<PromotionDTO> Add(PromotionDTO promotionRequest)
        {
            var promotion = _mapper.Map<Promotion>(promotionRequest);
            promotion.CreatedAt = DateTime.Now;
            promotion.UpdatedAt = DateTime.Now;

            promotion = await _promotionRepository.Add(promotion);
            var promotionDTO = _mapper.Map<PromotionDTO>(promotion);
            return promotionDTO;
        }

        public async Task<bool> Update(PromotionDTO promotionRequest)
        {
            var promotion = _mapper.Map<Promotion>(promotionRequest);
            var promotionOld = await _promotionRepository.GetById(promotion.Id);
            
            if(promotionOld == null)
            {
                return false;
            }

            promotion.CreatedAt = promotionOld.CreatedAt;
            promotion.UpdatedAt = DateTime.Now;
            return await _promotionRepository.Update(promotion);
        }

        public async Task<bool> RemoveById(string id)
        {
            return await _promotionRepository.RemoveById(id);
        }

        public async Task<bool> Remove(PromotionDTO promotionRequest)
        {
            var promotion = _mapper.Map<Promotion>(promotionRequest);
            return await _promotionRepository.Remove(promotion);
        }
    }
}
