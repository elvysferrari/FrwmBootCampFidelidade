using FrwkBootCampFidelidade.DTO.ProductContext;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionItemDTO
    {
        public string Id { get; set; }

        public string PromotionId { get; set; }

        public long ProductId { get; set; }

        public double DiscountPercentage { get; set; }
        public ProductDTO Product { get; set; }

    }
}
