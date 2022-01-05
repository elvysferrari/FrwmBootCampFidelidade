namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public abstract class PromotionItemBaseDTO
    {
        public string Id { get; set; }
        public string PromotionId { get; set; }
        public long ProductId { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
