using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping
{
    public class PromotionMap : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            //MSSQL
            //builder.HasData(ObterDados());
        }

        //private static ICollection<Promotion> ObterDados()
        //{
        //    DateTime createdAt = DateTime.Now;
        //    DateTime blackFridayStart = new DateTime(2021,11,1);
        //    DateTime blackFridayEnd = new DateTime(2021,11,30);
        //    DateTime natalStart = new DateTime(2021,12,15);
        //    DateTime natalEnd = new DateTime(2021,12,25);

        //    return new[]{
        //        new Promotion() {Id = 1, Description="Black Friday", DiscountPercentage = 10, StartDate = blackFridayStart, EndDate=blackFridayEnd, CreatedAt = createdAt, UpdatedAt = createdAt },
        //        new Promotion() {Id = 2, Description="Natal", DiscountPercentage = 20, StartDate = natalStart, EndDate=natalEnd, CreatedAt = createdAt, UpdatedAt = createdAt },
        //    };
        //}
    }
}
