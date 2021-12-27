using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Web.BootCampFidelidade.HttpAggregator.Infrastructute.Constants;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IRabbitMqService service;
        public WalletController(IRabbitMqService service)
        {
            this.service = service;
        }

        [HttpGet("GetByUserId/{userId:int}")]
        [Authorize]
        public ActionResult<List<WalletDTO>> GetByUserId(int userId)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.GETBYUSERID,
                Content = userId.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Ok(new { wallets });
        }

        [HttpGet("GetByUserIdAndType/{userId}/{walletType}")]
        [Authorize]
        public ActionResult<List<WalletDTO>> GetByUserIdAndType(int userId, int walletType)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.GETBYUSERIDANDTYPE,
                Content = JsonSerializer.Serialize(new { userId, walletType }),
            };

            var response = service.Call(message);
            service.Close();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Ok(new { wallets });
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Task<WalletDTO>> Post([FromBody] WalletDTO walletDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.POST,
                Content = JsonSerializer.Serialize(walletDTO),
            };

            var response = service.Call(message);
            service.Close();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Created($"{Request.Path}", new { wallets });

        }

        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] WalletDTO walletDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.POST,
                Content = JsonSerializer.Serialize(walletDTO),
            };

            var response = service.Call(message);
            service.Close();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Ok(new { wallets });
        }

    }
}
