using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasData(ObterDados());
    
        }
        private ICollection<OrderItem> ObterDados()
        {            
            return new[]{
                new OrderItem() { OrderId = 1, observation = "Medicamento X.1", ProductId = 1, quantity = 5 },
                new OrderItem() { OrderId = 1, observation = "Medicamento X.2", ProductId = 2, quantity = 15 },
                new OrderItem() { OrderId = 1, observation = "Medicamento X.3", ProductId = 3, quantity = 25 },
                new OrderItem() { OrderId = 2, observation = "Medicamento Y.1", ProductId = 4, quantity = 8 },
                new OrderItem() { OrderId = 2, observation = "Medicamento Y.2", ProductId = 5, quantity = 9 },
                new OrderItem() { OrderId = 2, observation = "Medicamento Y.3", ProductId = 6, quantity = 10 },
            };
        }
    }
}
