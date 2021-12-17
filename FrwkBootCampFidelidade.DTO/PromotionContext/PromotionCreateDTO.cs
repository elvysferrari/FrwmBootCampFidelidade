using System;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionCreateDTO
    {
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
