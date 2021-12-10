
using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using System;

namespace FrwkBootCampFidelidade.Dominio.BonificationContext.Entities
{
    public class Bonification
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int scoreQuantity { get; set; }
        public DateTime date { get; set; }        
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
