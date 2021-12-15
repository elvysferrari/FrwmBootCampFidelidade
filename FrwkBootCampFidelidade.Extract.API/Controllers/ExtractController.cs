using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.DTO.ExtractContext;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;

namespace FrwkBootCampFidelidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        private readonly IExtractService _ExtractService;
        public ExtractController(IExtractService ExtractService)
        {
            _ExtractService = ExtractService;
        }

        [HttpGet("GetByUserId/{userId}")]        
        public async Task<List<RansomHistoryStatusDTO>> GetByUserId(int userId)
        {
            List<RansomHistoryStatusDTO> extracts = await _ExtractService.GetByUserId(userId);
            return extracts;
        }

        [HttpGet("GetByCPF/{cpf}")]        
        public async Task<List<RansomHistoryStatusDTO>> GetByCPF(string cpf)
        {
            List<RansomHistoryStatusDTO> extracts = await _ExtractService.GetByCPF(cpf);
            return extracts;
        }

        [HttpGet("GetSummaryPointsByUserID/{userId}")]
        public async Task<List<SummaryPointsDTO>> GetSummaryPoints(int userId)
        {
            List<SummaryPointsDTO> extracts = await _ExtractService.GetSummaryPoints(userId);
            return extracts;
        }


    }
}
