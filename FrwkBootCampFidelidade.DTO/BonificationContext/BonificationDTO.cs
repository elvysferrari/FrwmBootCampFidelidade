using System;
using System.Collections.Generic;
using System.Text;

namespace FrwkBootCampFidelidade.DTO.BonificationContext
{
    public class BonificationDTO
    {
        public int Id { get; set; }        
        public int OrderId { get; set; }
        public int UserId { get; set; }        
        public DateTime date { get; set; }
        public int quantity { get; set; }
    }
}
