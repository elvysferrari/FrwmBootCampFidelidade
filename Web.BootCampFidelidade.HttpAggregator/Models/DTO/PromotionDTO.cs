using System;
using System.Collections.Generic;

namespace Web.BootCampFidelidade.HttpAggregator.Models.DTO
{
    public class PromotionDTO
    {
        public int Id { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
