using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.DTO.PromotionContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IRpcClientService _service;

        public PromotionController(IRpcClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var message = new MessageInputModel(
               DomainConstant.PROMOTION,
               MethodConstant.GET,
               string.Empty);

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            var message = new MessageInputModel(
                DomainConstant.PROMOTION,
                MethodConstant.GETBYID,
                id.ToString());

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetPromotionByDateRange")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public IActionResult GetPromotionByDateRange([FromQuery] long userId, long drugstoreId, string startDate, string endDate)
        {
            DateTime.TryParse(startDate, out DateTime _startDate);
            DateTime.TryParse(endDate, out DateTime _endDate);

            var promotionRequestDTO = new PromotionDTO
            {
                UserId = userId,
                DrugstoreId = drugstoreId,
                StartDate = _startDate,
                EndDate = _endDate
            };

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONBYDATERANGE,
                Content = JsonSerializer.Serialize(promotionRequestDTO),
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetPromotionToday")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPromotionToday()
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.GETPROMOTIONTODAY,
                Content = string.Empty,
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] PromotionDTO promotion)
        {

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.POST,
                Content = JsonSerializer.Serialize(promotion),
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return CreatedAtAction(nameof(GetById), new { id = promotions.Id }, promotions);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromQuery(Name = "id")][Required] string id, [FromBody][Required] PromotionDTO promotion)
        {

            if (string.IsNullOrEmpty(id))
                return BadRequest("Id do usuário é obrigatório.");

            promotion.Id = id.ToString();

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.PUT,
                Content = JsonSerializer.Serialize(promotion)
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute][Required] int id)
        {
            if (id == 0) return BadRequest("Id do usuário é obrigatório.");

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.DELETE,
                Content = id.ToString(),
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute][Required] string id, [FromBody][Required] PromotionDTO promotion)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id do usuário é obrigatório.");

            var message = new MessageInputModel(DomainConstant.PROMOTION, MethodConstant.GETPROMOTIONBYDATERANGE, JsonConvert.SerializeObject(promotion));

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PROMOTION,
                Method = MethodConstant.DELETEBYID,
                Content = id.ToString(),
            };

            var response = _service.Call(message);
            _service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }
    }
}
