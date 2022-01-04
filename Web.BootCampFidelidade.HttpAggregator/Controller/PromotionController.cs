using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> Get()
        {
            var message = new MessageInputModel(
               DomainConstant.PROMOTION,
               MethodConstant.GET,
               string.Empty);

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetById")]
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

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpGet("GetPromotionByDateRange")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPromotionByDateRange([FromQuery] long userId, long drugstoreId, string startDate, string endDate)
        {
            var message = new MessageInputModel(
               DomainConstant.PROMOTION,
               MethodConstant.GETPROMOTIONBYDATERANGE,
               JsonConvert.SerializeObject(new PromotionDTO { UserId = userId, DrugstoreId = drugstoreId, StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) }));

            var response = await service.Call(message);
            service.Close();

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
            var message = new MessageInputModel(
                DomainConstant.PROMOTION,
                MethodConstant.GETBYUSERID,
                string.Empty);

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<IEnumerable<PromotionDTO>>(response);

            return Ok(new { promotions });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] PromotionDTO promotion)
        {

            var message = new MessageInputModel(
                DomainConstant.PROMOTION,
                MethodConstant.GETPROMOTIONBYDATERANGE,
                JsonConvert.SerializeObject(promotion));

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return CreatedAtAction(nameof(GetById), new { id = promotions.Id }, promotions);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute][Required] int id, [FromBody][Required] PromotionDTO promotion)
        {

            if (id == 0) 
                return BadRequest("Id do usuário é obrigatório.");

            promotion.Id = id.ToString();

            var message = new MessageInputModel(
                DomainConstant.PROMOTION,
                MethodConstant.GETPROMOTIONBYDATERANGE,
                JsonConvert.SerializeObject(promotion));

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute][Required] int id)
        {
            if (id == 0) return BadRequest("Id do usuário é obrigatório.");

            var message = new MessageInputModel(DomainConstant.PROMOTION, MethodConstant.GETPROMOTIONBYDATERANGE, id.ToString());

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody][Required] PromotionDTO promotion)
        {

            var message = new MessageInputModel(DomainConstant.PROMOTION, MethodConstant.GETPROMOTIONBYDATERANGE, JsonConvert.SerializeObject(promotion));

            var response = await service.Call(message);
            service.Close();

            var promotions = JsonConvert.DeserializeObject<PromotionDTO>(response);

            return Ok(new { promotions });
        }
    }
}
