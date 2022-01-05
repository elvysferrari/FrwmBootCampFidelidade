using System;
using System.Collections.Generic;
using System.Linq;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionDTO : PromotionBaseDTO<PromotionItemDTO>, ICloneable
    {
        public object Clone()
        {
            var promotionDTO = (PromotionDTO)MemberwiseClone();
            var promotionItemsDTO = new List<PromotionItemDTO>();
            promotionDTO.PromotionItems.ToList().ForEach(x => promotionItemsDTO.Add((PromotionItemDTO)x.Clone()));
            promotionDTO.PromotionItems = promotionItemsDTO;
            return promotionDTO;
        }

        public PromotionDTO CloneTyped()
        {
            return (PromotionDTO)Clone();
        }
    }
}
