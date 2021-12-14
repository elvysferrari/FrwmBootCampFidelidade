using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.DTO.RansomContext;
using System.Collections.Generic;
using System.Threading.Tasks;
//using AutoMapper;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class RansomService : IRansomService
    {
        private readonly IRansom _ransom;
        private readonly IMapper _mapper;

        public RansomService(IRansom bonification, IMapper mapper)
        {
            _ransom = bonification;
            _mapper = mapper;
        }

        public async Task Add(RansomDTO obj)
        {
            var ransom = _mapper.Map<Ransom>(obj);
            await _ransom.Add(ransom);
        }

        public async Task<RansomDTO> GetById(int Id)
        {
            RansomDTO ransomDTO = _mapper.Map<RansomDTO>(await _ransom.GetById(Id));
            return ransomDTO;
        }

        public IEnumerable<RansomDTO> GetAll()
        {
            var teste = _ransom.GetAll();
            IEnumerable<RansomDTO> ransomDTOs = _mapper.Map<IEnumerable<RansomDTO>>(teste);

            return ransomDTOs;
        }

        public async Task<List<RansomDTO>> GetListByCPF(string cpf)
        {
            List<RansomDTO> ransomDTOs = _mapper.Map<List<RansomDTO>>(await _ransom.GetListByCPF(cpf));
            return ransomDTOs;
        }

        
    }
}
