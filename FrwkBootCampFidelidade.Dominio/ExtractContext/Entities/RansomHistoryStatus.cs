using FrwkBootCampFidelidade.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;

namespace FrwkBootCampFidelidade.Dominio.ExtractContext.Entities
{
    public class RansomHistoryStatus : EntityBase
    {
        public int RansomStatusId { get; set; }
        public RansomStatus RansomStatus { get; set; }
        public int RansomId { get; set; }
        public Ransom Ransom { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
