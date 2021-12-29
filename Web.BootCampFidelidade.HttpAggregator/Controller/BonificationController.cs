using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BonificationController : ControllerBase
    {
        private readonly IRpcClientService service;

        public BonificationController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpGet("{userId:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BonificationDTO), StatusCodes.Status200OK)]
        public ActionResult<BonificationDTO> GetByUserId([FromQuery(Name = "userId")][Required] int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYUSERID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound("");

            var bonifications = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { bonifications });
        }

        [HttpGet("{cpf}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BonificationDTO), StatusCodes.Status200OK)]
        public ActionResult<BonificationDTO> GetByCPF([FromQuery(Name = "cpf")][Required] string cpf)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYCPF,
                Content = cpf,
            };

            var response = service.Call(message);
            service.Close();

            var bonifications = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { bonifications });
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PromotionDTO), StatusCodes.Status201Created)]
        public ActionResult Post([FromBody][Required] BonificationDTO bonificationDTO)
        {

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYCPF,
                Content = JsonSerializer.Serialize(bonificationDTO),
            };

            var response = service.Call(message);
            service.Close();

            var bonifications = JsonSerializer.Deserialize<BonificationDTO>(response);


            return Created($"{Request.Path}/{bonifications.Id}", new { bonifications });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BonificationDTO), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GET,
                Content = string.Empty,
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound("");

            var bonifications = JsonSerializer.Deserialize<List<BonificationDTO>>(response);

            return Ok(new { bonifications });

        }
    }
}
