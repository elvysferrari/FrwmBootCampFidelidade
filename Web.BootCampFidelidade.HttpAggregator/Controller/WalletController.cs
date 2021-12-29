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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IRpcClientService service;
        public WalletController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status200OK)]
        public ActionResult<List<WalletDTO>> GetByUserId([FromQuery(Name = "userId")][Required]int id)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.GETBYUSERID,
                Content = id.ToString(),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Ok(new { wallets });
        }

        [HttpGet("{id:int}/{walletType}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status200OK)]
        public ActionResult<List<WalletDTO>> GetByUserIdAndType([FromQuery(Name = "userId")][Required] int id, [FromQuery(Name = "walletType")][Required] int type)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.GETBYUSERIDANDTYPE,
                Content = JsonSerializer.Serialize(new { id, type }),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var wallets = JsonSerializer.Deserialize<List<WalletDTO>>(response);

            return Ok(new { wallets });
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status201Created)]
        public ActionResult<Task<WalletDTO>> Post([FromBody][Required] WalletDTO walletDTO)
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.POST,
                Content = JsonSerializer.Serialize(walletDTO),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var wallets = JsonSerializer.Deserialize<WalletDTO>(response);

            return Created($"{Request.Path}/{wallets.Id}", new { wallets });

        }

        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status200OK)]
        public ActionResult Put([FromQuery(Name = "userId")][Required] int id, [FromBody][Required] WalletDTO walletDTO)
        {
            if (id == 0)
               return BadRequest("Usuário é obrigátorio.");

            walletDTO.Id = id;

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

        [HttpPost("Transfer")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RansomDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult> WalletTransfer([FromBody][Required] WalletTransferDTO walletTransferDTO)
        {
            if (walletTransferDTO == null)
                return NotFound();

            var message = new MessageInputModel()
            {
                Queue = DomainConstant.WALLET,
                Method = MethodConstant.TRANSFER,
                Content = JsonSerializer.Serialize(walletTransferDTO),
            };

            var response = service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var walletTransfers = JsonSerializer.Deserialize<WalletTransferDTO>(response);

            return Created($"{Request.Path}/{walletTransfers.WalletOriginId}/{walletTransfers.WalletTargetId}", new { walletTransfers });

        }

    }
}
