using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Entities
{
    public class PromotionItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PromotionId")]
        public string PromotionId { get; set; }

        [BsonElement("ProductId")]
        public long ProductId { get; set; }

        [BsonElement("DiscountPercentage")]
        public double DiscountPercentage { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
