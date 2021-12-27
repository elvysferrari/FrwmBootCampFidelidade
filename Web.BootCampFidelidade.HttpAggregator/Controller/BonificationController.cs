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
    [ApiController]
    public class BonificationController : ControllerBase
    {
        private readonly IRabbitMqService service;

        public BonificationController(IRabbitMqService service)
        {
            this.service = service;
        }

        [HttpGet("GetByUserId/{userId:int}")]
        [Authorize]
        public ActionResult<BonificationDTO> GetByUserId(int userId)
        {

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYUSERID,
                Content = userId.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { products });
        }

        [HttpGet("GetByCPF/{cpf}")]
        [Authorize]
        public ActionResult<BonificationDTO> GetByCPF(string cpf)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYCPF,
                Content = cpf.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);

            return Ok(new { products });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] BonificationDTO bonificationDTO)
        {

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.BONIFICATION,
                Method = MethodConstant.GETBYCPF,
                Content = JsonSerializer.Serialize(bonificationDTO),
            };

            var response = service.Call(message);
            service.Close();

            var products = JsonSerializer.Deserialize<IEnumerable<BonificationDTO>>(response);
                

            return Created($"{Request.Path}", new { products });
        }
    }
}
