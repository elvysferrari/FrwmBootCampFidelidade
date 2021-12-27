using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Mapping
{
    public class PromotionItemContextSeed
    {
        public static void SeedData(IMongoCollection<PromotionItem> promotionItemCollection)
        {
            bool existPromotionsItems = promotionItemCollection.Find(x => true).Any();

            if (!existPromotionsItems)
            {
                promotionItemCollection.InsertManyAsync(GetMyPromotions());
            }
        }

        private static IEnumerable<PromotionItem> GetMyPromotions()
        {
            DateTime createdAt = DateTime.Now;

            return new[]{
                new PromotionItem()
                {
                    DiscountPercentage = 10,
                    ProductId = 1,
                    PromotionId = "61ca0c75af617fc6b0458414",
                    CreatedAt = createdAt,
                    UpdatedAt = createdAt
                },
                new PromotionItem()
                {
                    DiscountPercentage = 5,
                    ProductId = 1,
                    PromotionId = "61ca0c75af617fc6b0458414",
                    CreatedAt = createdAt,
                    UpdatedAt = createdAt
                }
            };
        }
    }
}
