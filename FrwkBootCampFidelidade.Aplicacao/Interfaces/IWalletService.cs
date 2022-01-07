﻿using FrwkBootCampFidelidade.DTO.WalletContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IWalletService
    {
        Task Add(WalletDTO wallet);
        Task Update(WalletDTO wallet);
        Task<List<WalletDTO>> GetAllByUserId(int userId);
        Task<List<WalletDTO>> GetByUserIdAndType(int userId, int walletType);
        Task Transfer(WalletTransferDTO walletTransferDTO);
        Task Withdraw(WalletWithdrawDTO walletWithdrawDTO);
        Task UpdateWalletAmountValue(int userId, float scoreQuantity);
    }
}

