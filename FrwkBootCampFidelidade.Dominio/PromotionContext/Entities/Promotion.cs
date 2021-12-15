using FrwkBootCampFidelidade.Dominio.Base;
using FrwkBootCampFidelidade.Dominio.ProductContext.Entities;
using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Entities
{
    public class Promotion : EntityBase
    {
        //public List<Product> Products { get; set; }
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
