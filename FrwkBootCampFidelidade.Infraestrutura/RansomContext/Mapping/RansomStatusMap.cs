using FrwkBootCampFidelidade.Dominio.RansomContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.RansomContext.Mapping
{
    public class RansomStatusMap : IEntityTypeConfiguration<RansomStatus>
    {
        public void Configure(EntityTypeBuilder<RansomStatus> builder)
        {
            builder.ToTable("Ransom");

            builder.HasKey(prop => prop.Id);

            builder.Property(x => x.Name);

        }
    }
}
