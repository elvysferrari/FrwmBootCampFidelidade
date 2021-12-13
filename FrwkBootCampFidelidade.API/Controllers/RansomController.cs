using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RansomController : ControllerBase
    {
        private readonly IRansomRepository _ransom;
        public RansomController(IRansomRepository ransom)
        {
            _ransom = ransom;
        }

        [HttpGet]
        public async Task<List<Ransom>> GetAll()
        {
            List<Ransom> ransoms = await _ransom.GetAll().ToListAsync();
            return ransoms;
        }
    }
}
