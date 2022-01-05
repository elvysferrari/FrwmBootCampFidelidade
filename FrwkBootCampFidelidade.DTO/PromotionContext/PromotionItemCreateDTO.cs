namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionItemCreateDTO
    {
        public string Id { get; set; }
        public string PromotionId { get; set; }
        public long ProductId { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
