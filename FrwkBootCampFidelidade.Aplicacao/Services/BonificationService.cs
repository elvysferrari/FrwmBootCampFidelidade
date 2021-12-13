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
        private readonly IBonificationRepository _bonification;
        private readonly IMapper _mapper;

        public BonificationService(IBonificationRepository bonification, IMapper mapper)
        {
            _bonification = bonification;
            _mapper = mapper;
        }

        public async Task Add(BonificationDTO obj)
        {
            var bonification = _mapper.Map<Bonification>(obj);
            await _bonification.Add(bonification);
            await _bonification.SaveChanges();
        }

        public async Task<List<BonificationDTO>> GetByCPF(string CPF)
        {
            var bonifications = await _bonification.GetByCPF(CPF);
            return _mapper.Map<List<BonificationDTO>>(bonifications);
        }

        public async Task<List<BonificationDTO>> GetByUserId(int userId)
        {
            var bonifications = await _bonification.GetByUserId(userId);
            return _mapper.Map<List<BonificationDTO>>(bonifications);
        }
    }
}
