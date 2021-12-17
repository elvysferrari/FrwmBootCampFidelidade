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
        public RansomController(IRansomService ransomService)
        {
            _ransomService = ransomService;
        }

        [HttpPost]
        public RansomDTO AddRansom([FromBody] RansomDTO ransomDTO)
        {
            _ransomService.Add(ransomDTO);
            return ransomDTO;
        }

        [HttpGet]
        public IEnumerable<RansomDTO> GetAll()
        {
            IEnumerable<RansomDTO> ransoms = _ransomService.GetAll();
            return ransoms;
        }

        [HttpGet("GetByCPF/{cpf}")]
        public async Task<IEnumerable<RansomDTO>> GetByCPF(string cpf)
        {
            IEnumerable<RansomDTO> bonifications = await _ransomService.GetListByCPF(cpf);
            return bonifications;
        }
    }
}
