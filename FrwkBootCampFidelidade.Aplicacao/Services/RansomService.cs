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
        private readonly IRansomRepository _ransomRepository;
        private readonly IMapper _mapper;

        public RansomService(IRansomRepository ransomRepository, IMapper mapper)
        {
            _ransomRepository = ransomRepository;
            _mapper = mapper;
        }

        public async Task Add(RansomDTO obj)
        {
            Ransom ransom = _mapper.Map<Ransom>(obj);
            await _ransomRepository.Add(ransom);
        }

        public async Task Remove(RansomDTO ransomDTO)
        {
            Ransom ransom = _mapper.Map<Ransom>(ransomDTO);
            _ransomRepository.Remove(ransom);
        }

        public async Task<RansomDTO> GetById(int Id)
        {
            RansomDTO ransomDTO = _mapper.Map<RansomDTO>(await _ransomRepository.GetById(Id));
            return ransomDTO;
        }

        public IEnumerable<RansomDTO> GetAll()
        {
            var teste = _ransomRepository.GetAll();
            IEnumerable<RansomDTO> ransomDTOs = _mapper.Map<IEnumerable<RansomDTO>>(teste);

            return ransomDTOs;
        }

        public async Task<List<RansomDTO>> GetListByCPF(string cpf)
        {
            List<RansomDTO> ransomDTOs = _mapper.Map<List<RansomDTO>>(await _ransomRepository.GetListByCPF(cpf));
            return ransomDTOs;
        }

        
    }
}
