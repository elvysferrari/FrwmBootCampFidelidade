using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.DTO.ProductContext;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class PromotionItemService : IPromotionItemService
    {
        private readonly IMapper _mapper;
        private readonly IPromotionItemRepository _promotionItemRepository;
        private readonly IProductService _productService;

        public PromotionItemService(IPromotionItemRepository promotionItemRepository, IMapper mapper,
            IProductService productService)
        {
            _mapper = mapper;
            _promotionItemRepository = promotionItemRepository;
            _productService = productService;
        }

        private async Task<ProductDTO> GetProduct(long productId)
        {
            return await _productService.GetById(productId);
        }

        public async Task<IEnumerable<PromotionItemDTO>> GetAll()
        {
            var items = await _promotionItemRepository.GetAll();
            var itemsDTO = _mapper.Map<IEnumerable<PromotionItemDTO>>(items);

            foreach (var item in itemsDTO)
            {
                item.Product = await GetProduct(item.ProductId);
            }

            return itemsDTO;
        }

        public async Task<IEnumerable<PromotionItemDTO>> GetPromotionItemsByPromotionId(string promotionId)
        {
            var items = await _promotionItemRepository.GetPromotionItemsByPromotionId(promotionId);
            var itemsDTO = _mapper.Map<IEnumerable<PromotionItemDTO>>(items);

            foreach (var item in itemsDTO)
            {
                item.Product = await GetProduct(item.ProductId);
            }

            return itemsDTO;
        }

        public async Task<PromotionItemDTO> GetById(string id)
        {
            var item = await _promotionItemRepository.GetById(id);

            if(item == null)
            {
                return null;
            }

            var itemDTO = _mapper.Map<PromotionItemDTO>(item);
            itemDTO.Product = await GetProduct(item.ProductId);
            return itemDTO;
        }

        public async Task<PromotionItemDTO> Add(PromotionItemCreateDTO promotionItem)
        {
            var item = _mapper.Map<PromotionItem>(promotionItem);
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;

            item = await _promotionItemRepository.Add(item);
            var itemDTO = _mapper.Map<PromotionItemDTO>(item);
            return itemDTO;
        }

        public async Task<bool> Update(PromotionItemUpdateDeleteDTO promotionItem)
        {
            var item = _mapper.Map<PromotionItem>(promotionItem);
            var itemOld = await _promotionItemRepository.GetById(item.Id);

            if (itemOld == null)
            {
                return false;
            }

            item.CreatedAt = itemOld.CreatedAt;
            item.UpdatedAt = DateTime.Now;
            return await _promotionItemRepository.Update(item);
        }

        public async Task<bool> RemoveById(string id)
        {
            return await _promotionItemRepository.RemoveById(id);
        }

        public async Task<bool> Remove(PromotionItemUpdateDeleteDTO promotionItem)
        {
            var item = _mapper.Map<PromotionItem>(promotionItem);
            return await _promotionItemRepository.Remove(item);
        }
    }
}
