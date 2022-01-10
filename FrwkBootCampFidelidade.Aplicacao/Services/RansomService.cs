using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Interfaces;
using FrwkBootCampFidelidade.DTO.RansomContext;
using FrwkBootCampFidelidade.DTO.WalletContext;
using System.Collections.Generic;
using System.Threading.Tasks;
//using AutoMapper;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class RansomService : IRansomService
    {
        private readonly IRansomRepository _ransomRepository;
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public RansomService(IRansomRepository ransomRepository, IWalletService walletService, IMapper mapper)
        {
            _ransomRepository = ransomRepository;
            _walletService = walletService;
            _mapper = mapper;
        }

        public async Task Add(RansomDTO ransomDTO)
        {
            Ransom ransom = _mapper.Map<Ransom>(ransomDTO);

            await _walletService.Withdraw(new WalletWithdrawDTO { WalletId = (int)ransomDTO.WalletId, Amount = ransomDTO.Amount });

            await _ransomRepository.Add(ransom);
        }

        public async Task Remove(RansomDTO ransomDTO)
        {
            Ransom ransom = _mapper.Map<Ransom>(ransomDTO);
            _ransomRepository.Remove(ransom);
        }

        public async Task<RansomDTO> GetById(int Id)
        {
            var ransoms = await _ransomRepository.GetById(Id);
            return _mapper.Map<RansomDTO>(ransoms);
        }

        public IEnumerable<RansomDTO> GetAll()
        {
            var ransoms = _ransomRepository.GetAll();
            return _mapper.Map<IEnumerable<RansomDTO>>(ransoms);
        }

        public async Task<List<RansomDTO>> GetListByCPF(string cpf)
        {
            List<RansomDTO> ransomDTOs = _mapper.Map<List<RansomDTO>>(await _ransomRepository.GetListByCPF(cpf));
            return ransomDTOs;
        }
    }
}
