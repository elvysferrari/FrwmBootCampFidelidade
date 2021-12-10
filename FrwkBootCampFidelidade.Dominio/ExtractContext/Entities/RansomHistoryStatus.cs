using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.ExtractContext.Entities
{
    public class RansomHistoryStatus
    {
        public int Id { get; set; }
        public int ransomStatusId { get; set; }
        public object ransomStatus { get; set; }
        public int ransomId { get; set; }
        public object ransom { get; set; }
        public DateTime date { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
