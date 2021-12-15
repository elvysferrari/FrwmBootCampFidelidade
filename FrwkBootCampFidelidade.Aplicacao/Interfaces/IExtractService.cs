using FrwkBootCampFidelidade.DTO.ExtractContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IExtractService
    {
        Task Add(RansomHistoryStatusDTO obj);
        Task<List<RansomHistoryStatusDTO>> GetByUserId(int userId);
        Task<List<RansomHistoryStatusDTO>> GetByCPF(string CPF);
        Task<List<SummaryPointsDTO>> GetSummaryPoints(int userId);
    }
}
