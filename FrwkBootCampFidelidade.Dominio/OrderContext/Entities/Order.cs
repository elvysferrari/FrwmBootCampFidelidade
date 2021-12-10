using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Dominio.OrderContext.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public double TotalValue { get; set; }
        public object Store { get; set; }
        public object User { get; set; }
        public string cpf { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
