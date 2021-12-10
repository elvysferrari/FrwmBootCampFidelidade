using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Mapping
{
    public class RansomHistoryStatus : IEntityTypeConfiguration<Dominio.ExtractContext.Entities.RansomHistoryStatus>
    {
        public void Configure(EntityTypeBuilder<Dominio.ExtractContext.Entities.RansomHistoryStatus> builder)
        {
            builder.ToTable("Extract");

            builder.Property(x => x.date).HasColumnType("smalldatetime").IsRequired();

           // builder.HasKey(prop => prop.value);
        }
    }
}
