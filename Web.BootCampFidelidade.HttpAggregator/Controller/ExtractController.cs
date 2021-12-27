using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Web.BootCampFidelidade.HttpAggregator.Infrastructute.Constants;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;
using Web.BootCampFidelidade.HttpAggregator.Service.Interface;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    public class ExtractController : ControllerBase
    {
        private readonly IRabbitMqService service;
        public ExtractController(IRabbitMqService service)
        {
            this.service = service;
        }

        [HttpGet("GetByUserId/{userId}")]
        [Authorize]
        public ActionResult<RansomHistoryStatusDTO> GetByUserId(int userId)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETBYUSERID,
                Content = userId.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var extract = JsonSerializer.Deserialize<List<RansomHistoryStatusDTO>>(response);

            return Ok(new { extract });
        }

        [HttpGet("GetByCPF/{cpf}")]
        [Authorize]
        public ActionResult<RansomHistoryStatusDTO> GetByCPF(string cpf)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETBYCPF,
                Content = cpf.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var extract = JsonSerializer.Deserialize<List<RansomHistoryStatusDTO>>(response);

            return Ok(new { extract });
        }

        [HttpGet("GetSummaryPointsByUserID/{userId}")]
        [Authorize]
        public ActionResult<SummaryPointsDTO> GetSummaryPoints(int userId)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.EXTRACT,
                Method = MethodConstant.GETSUMMARYPOINTSBYUSERID,
                Content = userId.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var extract = JsonSerializer.Deserialize<List<RansomHistoryStatusDTO>>(response);

            return Ok(new { extract });
        }
    }
}
