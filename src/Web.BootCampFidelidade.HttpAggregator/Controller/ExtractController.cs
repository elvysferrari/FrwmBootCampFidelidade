using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    public class ExtractController : ControllerBase
    {
        private readonly IRpcClientService service;
        public ExtractController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomHistoryStatusDTO), StatusCodes.Status200OK)]
        public ActionResult<RansomHistoryStatusDTO> GetByUserId([FromQuery(Name = "userId")] int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETBYUSERID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var extracts = JsonSerializer.Deserialize<List<RansomHistoryStatusDTO>>(response);

            return Ok(new { extracts });
        }

        [HttpGet("{cpf}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomHistoryStatusDTO), StatusCodes.Status200OK)]
        public ActionResult<RansomHistoryStatusDTO> GetByCPF([FromQuery(Name = "cpf")] string cpf)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETBYCPF,
                Content = cpf,
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var extracts = JsonSerializer.Deserialize<List<RansomHistoryStatusDTO>>(response);

            return Ok(new { extracts });
        }

        [HttpGet("GetSummaryPointsByUserID/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SummaryPointsDTO), StatusCodes.Status200OK)]
        public ActionResult<SummaryPointsDTO> GetSummaryPoints([FromQuery(Name = "userId")][Required]int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETSUMMARYPOINTSBYUSERID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var extracts = JsonSerializer.Deserialize<List<SummaryPointsDTO>>(response);

            return Ok(new { extracts });
        }
    }
}
