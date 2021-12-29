using FrwkBootCampFidelidade.DTO.RansomContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Web.BootCampFidelidade.HttpAggregator.Infrastructute.Constants;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Service.Interface;

namespace FrwkBootCampFidelidade.Bff.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RansomController : ControllerBase
    {
        private readonly IRabbitMqService _service;

        public RansomController(IRabbitMqService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<RansomDTO> GetAll()
        {
            IEnumerable<RansomDTO> ransoms = new List<RansomDTO>();

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.RANSOM,
                Method = MethodConstant.GET,
                Content = JsonSerializer.Serialize(ransoms),
            };

            var response = _service.Call(message);
            _service.Close();

            ransoms = JsonSerializer.Deserialize<List<RansomDTO>>(response);

            return ransoms;
        }

        [HttpGet("GetByCPF/{cpf}")]
        [Authorize]
        public ActionResult<Task<IEnumerable<RansomDTO>>> GetByCPF(Message message)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.RANSOM,
                Method = MethodConstant.GETBYCPF,
                Content = JsonSerializer.Serialize(cpf),
            };

            var response = _service.Call(message);
            _service.Close();

            var ransom = JsonSerializer.Deserialize<IEnumerable<RansomDTO>>(response);

            return Ok(new { ransom });
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Task<RansomDTO>> AddRansom([FromBody] RansomDTO ransomDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.RANSOM,
                Method = MethodConstant.POST,
                Content = JsonSerializer.Serialize(ransomDTO),
            };

            var response = _service.Call(message);
            _service.Close();

            var ransom = JsonSerializer.Deserialize<List<RansomDTO>>(response);

            return Created($"{Request.Path}", new { ransom });
        }

    }
}
