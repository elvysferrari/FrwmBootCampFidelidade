using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using FrwkBootCampFidelidade.DTO.BonificationContext;
using FrwkBootCampFidelidade.DTO.WalletContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class BonificationService : IBonificationService
    {
        private readonly IBonificationRepository _bonification;
        private readonly IMapper _mapper;
        private readonly IWalletService _walletService;

        public BonificationService(IBonificationRepository bonification, IMapper mapper, IWalletService walletService)
        {
            _bonification = bonification;
            _walletService = walletService;
            _mapper = mapper;
        }

        public async Task Add(BonificationDTO bonificationDTO)
        {
            var bonification = _mapper.Map<Bonification>(bonificationDTO);

            if (bonificationDTO != null)
            {
                bonification.ScoreQuantity = CalculateScoreByValue(bonificationDTO.TotalValue);

                bonification.Date = DateTime.Now;
                bonification.CreatedAt = bonification.Date;
                bonification.UpdatedAt = bonification.Date;

                await _bonification.Add(bonification);
                await _bonification.SaveChanges();

                _walletService.UpdateWalletAmountValue();
            }
        }

        private float CalculateScoreByValue(float totalValue)
        {
            return totalValue / 100 * 1;
        }

        public async Task<IEnumerable<BonificationDTO>> GetByCPF(string CPF)
        {
            var bonifications = await _bonification.GetByCPF(CPF);
            return _mapper.Map<IEnumerable<BonificationDTO>>(bonifications);
        }

        public async Task<IEnumerable<BonificationDTO>> GetByUserId(int userId)
        {
            var bonifications = await _bonification.GetByUserId(userId);
            return _mapper.Map<IEnumerable<BonificationDTO>>(bonifications);
        }

        public IEnumerable<BonificationDTO> GetPendingBonification(string CPF)
        {
            var bonifications = _bonification.GetBy(x => x.CPF == CPF && x.ScoreCreditedAt == null);

            return _mapper.Map<IEnumerable<BonificationDTO>>(bonifications);
        }

        public async Task Remove(int Id)
        {
            Bonification bonification = await _bonification.GetById(Id);
            if (bonification != null)
            {
                try
                {
                    _bonification.Remove(Id);
                    await _bonification.SaveChanges();

                    //Atualizar carteira com o saldo novo
                    List<WalletDTO> walletsDTO = await _walletService.GetByUserIdAndType(Convert.ToInt32(bonification.UserId), 1);
                    if (walletsDTO.Count > 0)
                    {
                        WalletDTO walletDTO = walletsDTO.FirstOrDefault();
                        walletDTO.Amount -= bonification.ScoreQuantity;
                        if (walletDTO.Amount < 0)
                            walletDTO.Amount = 0;

                        _walletService.Update(walletDTO);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
