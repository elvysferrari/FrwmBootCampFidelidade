using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IRpcClientService service;
        public PromotionController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
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

        [HttpGet("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery(Name = "id")] int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETBYID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetPromotionByDateRange")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public IActionResult GetPromotionByDateRange([FromBody] PromotionDTO promotionRequestDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = JsonSerializer.Serialize(promotionRequestDTO),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetPromotionToday")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
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

            var promotions = JsonSerializer.Deserialize<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] PromotionDTO promotion)
        {

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = JsonSerializer.Serialize(promotion),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<PromotionDTO>(response);

            return CreatedAtAction(nameof(GetById), new { id = promotions.Id }, promotions);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromQuery(Name = "id")][Required] int id, [FromBody][Required] PromotionDTO promotion)
        {

            if (id == 0) return BadRequest("Id do usuário é obrigatório.");

            promotion.Id = id;

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = JsonSerializer.Serialize(promotion),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute][Required] int id)
        {
            if (id == 0) return BadRequest("Id do usuário é obrigatório.");

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute][Required] int id, [FromBody][Required] PromotionDTO promotion)
        {
            if (id == 0) return BadRequest("Id do usuário é obrigatório.");

            promotion.Id = id;

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var promotions = JsonSerializer.Deserialize<PromotionDTO>(response);

            return Ok(new { promotions });
        }
    }
}
