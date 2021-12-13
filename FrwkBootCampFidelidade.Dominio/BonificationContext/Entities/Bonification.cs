
using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using System;

namespace FrwkBootCampFidelidade.Dominio.BonificationContext.Entities
{
    public class Bonification
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public float ScoreQuantity { get; set; }
        public DateTime Date { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
