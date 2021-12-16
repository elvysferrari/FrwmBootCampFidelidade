using FrwkBootCampFidelidade.DTO.OrderContext;
using System;

namespace FrwkBootCampFidelidade.DTO.BonificationContext
{
    public class BonificationDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string CPF { get; set; }
        public float TotalValue { get; set; }
    }
}
