using FrwkBootCampFidelidade.DTO.BonificationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IBonificationService
    {
        Task Add(BonificationDTO obj);
        Task<IEnumerable<BonificationDTO>> GetByUserId(int userId);
        Task<IEnumerable<BonificationDTO>> GetByCPF(string CPF);        
    }
}
