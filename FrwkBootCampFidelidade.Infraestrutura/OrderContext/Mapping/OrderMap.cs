using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(prop => prop.Id);

            //builder.Property(x => x.date).HasColumnType("smalldatetime").IsRequired();            
        }
    }
}
