using FrwkBootCampFidelidade.DTO.WalletContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IWalletService
    {
        Task Add(WalletDTO wallet);
        void Update(WalletDTO wallet);
        Task<List<WalletDTO>> GetAllByUserId(int userId);
        Task<List<WalletDTO>> GetByUserIdAndType(int userId, int walletType);
    }
}
