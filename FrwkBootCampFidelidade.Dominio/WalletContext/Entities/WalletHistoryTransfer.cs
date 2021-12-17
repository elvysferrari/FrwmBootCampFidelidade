using FrwkBootCampFidelidade.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.WalletContext.Entities
{
    public class WalletHistoryTransfer : EntityBase
    {
        public int WalletOriginId { get; set; }
        public int WalletTargetId { get; set; }
        public float Quantity { get; set; }
        public DateTime CreatedAt { get; set; }   
    }
}
