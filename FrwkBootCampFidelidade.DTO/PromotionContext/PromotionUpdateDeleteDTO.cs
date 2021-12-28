using System;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public  class PromotionUpdateDeleteDTO
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public long DrugstoreId { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
