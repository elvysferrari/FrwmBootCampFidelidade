using FrwkBootCampFidelidade.Aplicacao.Constants;
using FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService;
using FrwkBootCampFidelidade.Dominio.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;

namespace Web.BootCampFidelidade.HttpAggregator.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRpcClientService service;
        public ProductController(IRpcClientService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
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
