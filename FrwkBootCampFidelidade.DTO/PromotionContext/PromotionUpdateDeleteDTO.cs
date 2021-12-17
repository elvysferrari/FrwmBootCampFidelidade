using System;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public  class PromotionUpdateDeleteDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
