using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RansomController : ControllerBase
    {
        private readonly IRpcClientService service;

        public RansomController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status201Created)]
        public ActionResult<RansomDTO> AddRansom([FromBody][Required] RansomDTO ransomDTO)
        {
            var message = InputModel(DomainConstant.RANSOM, MethodConstant.POST, JsonSerializer.Serialize(ransomDTO));

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var ransoms = JsonSerializer.Deserialize<RansomDTO>(response);

            return Created($"{Request.Path}/{ransoms.Id}", new { ransoms });
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RansomDTO>> GetAll()
        {
            var message = InputModel(DomainConstant.RANSOM, MethodConstant.GET, string.Empty);

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var ransoms = JsonSerializer.Deserialize<RansomDTO>(response);

            return Ok(new { ransoms });
        }

        [HttpGet("{cpf}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RansomDTO>> GetByCPF([FromQuery(Name = "cpf")][Required] string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return BadRequest("CPF deve ser informado.");

            var message = InputModel(DomainConstant.RANSOM, MethodConstant.GETBYCPF, cpf);

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var ransoms = JsonSerializer.Deserialize<RansomDTO>(response);

            return Ok(new { ransoms });
        }

        protected MessageInputModel InputModel(string queue, string method, string content)
        {
            return new MessageInputModel
            {
                Queue = queue,
                Method = method,
                Content = content
            };
        }

    }
}
