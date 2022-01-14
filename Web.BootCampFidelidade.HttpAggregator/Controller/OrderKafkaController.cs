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
using Confluent.Kafka;
using System;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderKafkaController : ControllerBase
    {
        private readonly IRpcClientService service;
        private readonly string bootstrapServers = "localhost:29092";
        private readonly string nomeTopic = "Orders";

        public OrderKafkaController(IRpcClientService service)
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

        public async Task<IActionResult> AddOrderKafka([FromBody][Required] string order) 
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(
                        nomeTopic,
                        new Message<Null, string>
                        { Value = nomeTopic });
                }

            }
            catch (Exception ex)
            {
            }

            return Created($"{Request.Path}", order);
        }

    }
}
