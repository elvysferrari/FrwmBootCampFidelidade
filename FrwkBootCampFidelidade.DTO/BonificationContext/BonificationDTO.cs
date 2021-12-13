using System;

namespace FrwkBootCampFidelidade.DTO.BonificationContext
{
    public class BonificationDTO
    {
        public int Id { get; set; }        
        public int OrderId { get; set; }
        public int UserId { get; set; }        
        public DateTime date { get; set; }
        public float scoreQuantity { get; set; }
    }
}
