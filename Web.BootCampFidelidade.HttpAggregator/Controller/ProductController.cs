using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Web.BootCampFidelidade.HttpAggregator.Infrastructute.Constants;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Service.Interface;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRabbitMqService service;
        public ProductController(IRabbitMqService service)
        {
            this.service = service;
        }

        public ActionResult<ProductDTO> Get()
        {
            var message = new MessageInputModel()
            {
                Queue = DomainConstant.PRODUCT,
                Method = MethodConstant.GET,
                Content = string.Empty,
            };

            var response = service.Call(message);
            service.Close();

            var product = JsonSerializer.Deserialize<List<ProductDTO>>(response);

            return Ok(new { product });
        }
    }
}
