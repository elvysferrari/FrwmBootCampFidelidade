using FrwkBootCampFidelidade.DTO.RansomContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces
{
    public interface IRansomService
    {
        Task Add(RansomDTO obj);
        Task<RansomDTO> GetById(int Id);
        IEnumerable<RansomDTO> GetAll();
        Task<List<RansomDTO>> GetListByCPF(string CPF);
    }
}
