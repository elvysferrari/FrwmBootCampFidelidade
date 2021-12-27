using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Web.BootCampFidelidade.HttpAggregator.Infrastructute.Constants;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IRabbitMqService service;
        public PromotionController(IRabbitMqService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GET,
                Content = string.Empty,
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetById/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETBYID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { products });
        }

        [HttpGet("GetPromotionByDateRange")]
        [Authorize]
        public IActionResult GetPromotionByDateRange([FromQuery] PromotionDTO promotionRequestDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = JsonSerializer.Serialize(promotionRequestDTO),
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { products });
        }

        [HttpGet("GetPromotionToday")]
        [Authorize]
        public IActionResult GetPromotionToday()
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETBYUSERID,
                Content = string.Empty,
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { products });
        }
    }
}
