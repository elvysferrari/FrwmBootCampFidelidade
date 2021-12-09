using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Mapping
{
    public class BonificationMap : IEntityTypeConfiguration<Bonification>
    {
        public void Configure(EntityTypeBuilder<Bonification> builder)
        {
            builder.ToTable("Bonification");

            builder.HasKey(prop => prop.Id);

            builder.Property(x => x.date).HasColumnType("smalldatetime").IsRequired();            
        }
    }
}
