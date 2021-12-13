﻿using AutoMapper;
using FrwkBootCampFidelidade.Aplicacao.Interfaces;
using FrwkBootCampFidelidade.Dominio.WalletContext.Entities;
using FrwkBootCampFidelidade.Dominio.WalletContext.Interfaces;
using FrwkBootCampFidelidade.DTO.WalletContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWallet _wallet;
        private readonly IMapper _mapper;

        public WalletService(IWallet wallet, IMapper mapper)
        {
            _wallet = wallet;
            _mapper = mapper;
        }
        public async Task Add(WalletDTO walletDTO)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);
            wallet.CreatedAt = DateTime.Now;
            wallet.UpdatedAt = DateTime.Now;

            await _wallet.Add(wallet);
            await _wallet.SaveChanges();
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

        public async void Update(WalletDTO walletDTO)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);
            wallet.UpdatedAt = DateTime.Now;
            _wallet.Update(wallet);
            await _wallet.SaveChanges();
        }
    }
}