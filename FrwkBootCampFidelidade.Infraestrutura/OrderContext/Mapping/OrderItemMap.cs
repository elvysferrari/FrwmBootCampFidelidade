using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(prop => prop.Id);

            //builder.Property(x => x.date).HasColumnType("smalldatetime").IsRequired();            
        }
    }
}
