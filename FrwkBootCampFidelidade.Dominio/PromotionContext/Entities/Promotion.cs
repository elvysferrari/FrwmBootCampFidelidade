using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Entities
{
    public class Promotion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DrugstoreId")]
        public long DrugstoreId { get; set; }

        [BsonElement("UserId")]
        public long UserId { get; set; }

        [BsonElement("Active")]
        public bool Active { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("StartDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("EndDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("PromotionItems")]
        public IEnumerable<PromotionItem> PromotionItems { get; set; }
    }
}
