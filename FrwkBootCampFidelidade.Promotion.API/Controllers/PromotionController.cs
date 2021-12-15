using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using FrwkBootCampFidelidade.Promotion.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Promotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var promotions = await _promotionService.GetAll();
                return Ok(new ResponseBase
                {
                    IsSuccess = true,
                    Message = "Sucesso.",
                    Object = promotions
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var promotion = await _promotionService.GetById(id);
                if(promotion == null)
                {
                    return Ok(new ResponseBase
                    {
                        IsSuccess = false,
                        Message = "Não foi encontrado nenhuma promoção com esse Id.",
                        Object = null
                    });
                }
                return Ok(new ResponseBase
                {
                    IsSuccess = true,
                    Message = "Sucesso.",
                    Object = promotion
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetPromotionByDateRange")]
        public async Task<IActionResult> GetPromotionByDateRange([FromQuery] PromotionRequestDTO promotionRequestDTO)
        {
            try
            {
                var promotions = await _promotionService.GetPromotionByDateRange(promotionRequestDTO);
                return Ok(new ResponseBase
                {
                    IsSuccess = true,
                    Message = "Sucesso.",
                    Object = promotions
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetPromotionToday")]
        public async Task<IActionResult> GetPromotionToday()
        {
            try
            {
                var promotions = await _promotionService.GetPromotionToday();
                return Ok(new ResponseBase
                {
                    IsSuccess = true,
                    Message = "Sucesso.",
                    Object = promotions
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
