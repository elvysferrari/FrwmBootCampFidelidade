using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.WalletContext.Entities;
using FrwkBootCampFidelidade.Dominio.WalletContext.Interfaces;
using FrwkBootCampFidelidade.DTO.WalletContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _wallet;
        private readonly IWalletHistoryTransferRepository _walletHistory;
        private readonly IBonificationService _bonification;
        private readonly IMapper _mapper;

        public WalletService(
            IWalletRepository wallet, 
            IMapper mapper, 
            IWalletHistoryTransferRepository walletHistory)
        {
            _wallet = wallet;
            _walletHistory = walletHistory;
            _mapper = mapper;
        }

        public async Task<WalletDTO> Add(WalletDTO walletDTO)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);
            wallet.CreatedAt = DateTime.Now;
            wallet.UpdatedAt = wallet.CreatedAt;

            await _wallet.Add(wallet);
            await _wallet.SaveChanges();

            await PendingBonificationForWalletScore(wallet, walletDTO.CPF);

            return _mapper.Map<WalletDTO>(wallet);
        }

        public async Task<List<WalletDTO>> GetAllByUserId(int userId)
        {
            var wallets = await _wallet.GetAllByUserId(userId);
            return _mapper.Map<List<WalletDTO>>(wallets);
        }

        public async Task<List<WalletDTO>> GetByUserIdAndType(int userId, int walletType)
        {
            var wallets = await _wallet.GetAllByUserIdAndType(userId, walletType);
            return _mapper.Map<List<WalletDTO>>(wallets);
        }

        public async Task Update(WalletDTO walletDTO)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);
            wallet.UpdatedAt = DateTime.Now;

            _wallet.Update(wallet);
            await _wallet.SaveChanges();
        }

        public async Task Transfer(WalletTransferDTO walletTransferDTO)
        {
            Wallet originWallet = await _wallet.GetById(walletTransferDTO.WalletOriginId);
            Wallet targetWallet = await _wallet.GetById(walletTransferDTO.WalletTargetId);

            if (originWallet != null && targetWallet != null && (originWallet.UserId == targetWallet.UserId))
            {
                if (originWallet.Amount >= walletTransferDTO.Quantity)
                {
                    originWallet.Amount -= walletTransferDTO.Quantity;
                    targetWallet.Amount += walletTransferDTO.Quantity;

                    originWallet.UpdatedAt = DateTime.Now;
                    targetWallet.UpdatedAt = DateTime.Now;

                    _wallet.Update(originWallet);
                    _wallet.Update(targetWallet);

                    await _wallet.SaveChanges();

                    var walletHistory = _mapper.Map<WalletHistoryTransfer>(walletTransferDTO);
                    walletHistory.CreatedAt = DateTime.Now;
                    await _walletHistory.Add(walletHistory);
                    await _walletHistory.SaveChanges();
                }
            }
        }

        public async Task Withdraw(WalletWithdrawDTO walletWithdrawDTO)
        {
            Wallet wallet = await _wallet.GetById(walletWithdrawDTO.WalletId);

            if (wallet != null && walletWithdrawDTO != null)
            {
                if (wallet.Amount >= walletWithdrawDTO.Amount)
                {
                    wallet.Amount -= walletWithdrawDTO.Amount;
                    wallet.UpdatedAt = DateTime.Now;

                    _wallet.Update(wallet);

                    await _wallet.SaveChanges();
                }
            }
        }

        public async Task UpdateWalletAmountValue(int userId, float scoreQuantity)
        {
            var wallets = await GetByUserIdAndType(userId, 1);

            if (wallets.Any())
            {
                var wallet = wallets.First();
                wallet.Amount += scoreQuantity;
                await Update(wallet);
            }
        }

        private async Task PendingBonificationForWalletScore(Wallet wallet, string cpf)
        {
            if (wallet.WalletTypeId == 1)
            {
                var amoutWallet = await _bonification.GetPendingBonificationsByCpf(cpf);

                wallet.Amount = amoutWallet;

                _wallet.Update(wallet);
                await _wallet.SaveChanges();
            }
        }
    }
}
