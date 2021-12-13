using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Mapping
{
    public class BonificationMap : IEntityTypeConfiguration<Bonification>
    {
        public void Configure(EntityTypeBuilder<Bonification> builder)
        {
            builder.ToTable("Bonification");
            builder.HasData(ObterDados());
        }
        private static ICollection<Bonification> ObterDados()
        {
            DateTime createdAt = new(2021, 12, 13, 15, 45, 23);

            return new[]{
                new Bonification() { OrderId = 1, ScoreQuantity = 52.0f, Date = createdAt, CreatedAt = createdAt, UpdatedAt = createdAt },
                new Bonification() { OrderId = 2, ScoreQuantity = 61.25f, Date = createdAt, CreatedAt = createdAt, UpdatedAt = createdAt }
            };
        }
    }
}
