using FrwkBootCampFidelidade.Dominio.WalletContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.WalletContext.Mapping
{
    public class WalletTypeMap : IEntityTypeConfiguration<WalletType>
    {
        public void Configure(EntityTypeBuilder<WalletType> builder)
        {
            builder.ToTable("WalletType");
        }
    }
}
