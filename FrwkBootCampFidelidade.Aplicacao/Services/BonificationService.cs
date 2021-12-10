using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.DTO.BonificationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class BonificationService : IBonificationService
    {
        private readonly IBonification _bonification;
        private readonly IMapper _mapper;

        public BonificationService(IBonification bonification, IMapper mapper)
        {
            _bonification = bonification;
            _mapper = mapper;
        }

        public async Task Add(BonificationDTO obj)
        {
            var bonification = _mapper.Map<Bonification>(obj);
            await _bonification.Add(bonification);
        }

        public async Task<List<BonificationDTO>> GetByCPF(string CPF)
        {
            return await _bonification.GetByCPF(CPF);
        }

        public async Task<List<BonificationDTO>> GetByUserId(int userId)
        {
            return await _bonification.GetByUserId(userId);
        }
    }
}
