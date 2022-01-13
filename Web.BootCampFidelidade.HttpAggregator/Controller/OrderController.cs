using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRpcClientService service;

        public OrderController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddOrder([FromBody][Required] OrderDTO orderDTO)
        {
            var message = new MessageInputModel(DomainConstant.ORDER, MethodConstant.POST, JsonConvert.SerializeObject(orderDTO));

            var response = await service.Call(message);
            service.Close();

            if (response.Equals(""))
                return NotFound();

            var orders = JsonConvert.DeserializeObject<OrderDTO>(response);

            return Created($"{Request.Path}/{orders.Id}", orders);
        }
    }
}
