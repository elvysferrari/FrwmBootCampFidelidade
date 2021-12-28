using System;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionRequestDTO
    {
        public long DrugstoreId { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
