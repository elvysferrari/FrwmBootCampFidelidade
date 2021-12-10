using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Mapping
{
    public class ExtractMap : IEntityTypeConfiguration<Extract>
    {
        public void Configure(EntityTypeBuilder<Extract> builder)
        {
            builder.ToTable("Extract");

           // builder.HasKey(prop => prop.Id);

          //  builder.Property(x => x.date).HasColumnType("smalldatetime").IsRequired();            
        }
    }
}
