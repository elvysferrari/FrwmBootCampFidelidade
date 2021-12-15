using System;
using System.ComponentModel.DataAnnotations;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
