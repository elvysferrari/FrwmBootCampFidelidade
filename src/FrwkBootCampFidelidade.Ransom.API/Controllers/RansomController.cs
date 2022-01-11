using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.DTO.RansomContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Ransom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RansomController : ControllerBase
    {
        private readonly IRansomService _ransomService;
        private readonly IMapper _mapper;

        public RansomController(IRansomService ransomService, IMapper mapper)
        {
            _ransomService = ransomService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddRansom([FromBody] RansomDTO ransomDTO)
        {
            if (ransomDTO == null) return BadRequest();

            try
            {
                await _ransomService.Add(ransomDTO);
                return Ok(ransomDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IEnumerable<RansomDTO> GetAll()
        {
            var ransomsDTO = _ransomService.GetAll();

            return ransomsDTO;
        }

        [HttpGet("GetByCPF/{cpf}")]
        public async Task<IEnumerable<RansomDTO>> GetByCPF(string cpf)
        {
            IEnumerable<RansomDTO> ransoms = await _ransomService.GetListByCPF(cpf);
            return ransoms;
        }
    }
}
