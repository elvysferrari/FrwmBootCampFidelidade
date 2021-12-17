using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping
{
    public class PromotionContextSeed
    {
        public static void SeedData(IMongoCollection<Promotion> promotionCollection)
        {
            bool existPromotions = promotionCollection.Find(x => true).Any();

            if (!existPromotions)
            {
                promotionCollection.InsertManyAsync(GetMyPromotions());
            }
        }

        private static IEnumerable<Promotion> GetMyPromotions()
        {
            DateTime createdAt = DateTime.Now;
            DateTime blackFridayStart = new DateTime(2021, 11, 1);
            DateTime blackFridayEnd = new DateTime(2021, 11, 30);
            DateTime natalStart = new DateTime(2021, 12, 15);
            DateTime natalEnd = new DateTime(2021, 12, 25);

            return new[]{
                new Promotion() {Id = "111111111111111111111111", Description="Black Friday", DiscountPercentage = 10, StartDate = blackFridayStart, EndDate=blackFridayEnd, CreatedAt = createdAt, UpdatedAt = createdAt },
                new Promotion() {Id = "111111111111111111111112", Description="Natal", DiscountPercentage = 20, StartDate = natalStart, EndDate=natalEnd, CreatedAt = createdAt, UpdatedAt = createdAt },
            };
        }
    }
}
