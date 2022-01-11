using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces;
using FrwkBootCampFidelidade.DTO.ExtractContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class ExtractService : IExtractService
    {
        private readonly IRansomHistoryStatusRepository _Extract;
        private readonly IMapper _mapper;

        public ExtractService(IRansomHistoryStatusRepository Extract, IMapper mapper)
        {
            _Extract = Extract;
            _mapper = mapper;
        }

        public async Task Add(RansomHistoryStatusDTO obj)
        {
            var Extract = _mapper.Map<RansomHistoryStatus>(obj);
            await _Extract.Add(Extract);
            await _Extract.SaveChanges();
        }

        public async Task<List<RansomHistoryStatusDTO>> GetByUserId(int userId)
        {
            var Extracts = await _Extract.GetByUserId(userId);
            return _mapper.Map<List<RansomHistoryStatusDTO>>(Extracts);
        }

        public async Task<List<RansomHistoryStatusDTO>> GetByCPF(string CPF)
        {
            var Extracts = await _Extract.GetByCPF(CPF);
            return _mapper.Map<List<RansomHistoryStatusDTO>>(Extracts);
        }

        public async Task<List<SummaryPointsDTO>> GetSummaryPoints(int userId)
        {
            var Extracts = await _Extract.GetSummaryPoints(userId);
            return _mapper.Map<List<SummaryPointsDTO>>(Extracts);
        }
    }
}
