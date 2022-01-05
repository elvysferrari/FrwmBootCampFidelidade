using FrwkBootCampFidelidade.DTO.ProductContext;
using System;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionItemDTO : ICloneable
    {
        public string Id { get; set; }
        public string PromotionId { get; set; }
        public long ProductId { get; set; }
        public double DiscountPercentage { get; set; }
        public ProductDTO Product { get; set; }

        public object Clone()
        {
            var promotionItem = (PromotionItemDTO)MemberwiseClone();
            promotionItem.Product = (ProductDTO)promotionItem.Product.Clone();
            return promotionItem;
        }
    }
}
