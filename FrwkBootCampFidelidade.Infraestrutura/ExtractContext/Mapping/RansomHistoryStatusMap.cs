using FrwkBootCampFidelidade.Dominio.ExtractContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;


namespace FrwkBootCampFidelidade.Infraestrutura.ExtractContext.Mapping
{
    public class RansomHistoryStatusMap : IEntityTypeConfiguration<RansomHistoryStatus>
    {
        public void Configure(EntityTypeBuilder<RansomHistoryStatus> builder)
        {
            builder.ToTable("Extract");

            builder.Property(x => x.Date).HasColumnType("smalldatetime").IsRequired();

           // builder.HasKey(prop => prop.value);
        }
    }
}
