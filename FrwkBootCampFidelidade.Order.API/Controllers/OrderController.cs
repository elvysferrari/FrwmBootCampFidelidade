using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.DTO.OrderContext;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Confluent.Kafka;
using System;

namespace FrwkBootCampFidelidade.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        private readonly string nomeTopic = "Orders";

        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderDTO orderDTO)
        {
            if (orderDTO == null) return BadRequest();

            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(
                        nomeTopic,
                        new Message<Null, string>
                        { Value = $"Id:{orderDTO.Id} / Cpf:{orderDTO.CPF}" });
                }

                return Created($"{Request.Path}", orderDTO);


                //await _OrderService.Add(orderDTO);
                //return Ok(orderDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> AddOrderKafka([FromBody] string order)
        //{
        //    try
        //    {
        //        var config = new ProducerConfig
        //        {
        //            BootstrapServers = "localhost:29092"
        //        };

        //        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        //        {
        //            var result = await producer.ProduceAsync(
        //                nomeTopic,
        //                new Message<Null, string>
        //                { Value = nomeTopic });
        //        }

        //        return Created($"{Request.Path}", order);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}
