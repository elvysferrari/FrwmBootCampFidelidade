using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.DTO.ExtractContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.ExtractContext.Interfaces
{
    public interface IRansomHistoryStatusRepository : IBaseRepository<RansomHistoryStatus>
    {
        //GetByUserId
        Task<List<RansomHistoryStatusDTO>> GetByUserId(int userId);
        Task<List<RansomHistoryStatusDTO>> GetByCPF(string CPF);
    }
}
