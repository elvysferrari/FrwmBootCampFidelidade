using FrwkBootCampFidelidade.Dominio.ProductContext.Entities;
using FrwkBootCampFidelidade.Dominio.ProductContext.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.ProductContext.Repository
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> _products = new List<Product>
        {
            new Product{Id=1,PromotionId="1", Name="Teste 1", Description="Remédio bom", Price=10.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=2,PromotionId="1", Name="Teste 2", Description="Remédio bom", Price=18.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=3,PromotionId="1", Name="Teste 3", Description="Remédio bom", Price=20.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=4,PromotionId="1", Name="Teste 4", Description="Remédio bom", Price=30.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=5,PromotionId="2", Name="Teste 5", Description="Remédio bom", Price=40.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=6,PromotionId="2", Name="Teste 6", Description="Remédio bom", Price=50.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=7,PromotionId="2", Name="Teste 7", Description="Remédio bom", Price=60.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=8,PromotionId="2", Name="Teste 8", Description="Remédio bom", Price=70.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
            new Product{Id=9,PromotionId="2", Name="Teste 9", Description="Remédio bom", Price=80.9, CreatedAt=System.DateTime.Now,UpdatedAt=System.DateTime.Now },
        };

        public IEnumerable<Product> GetByPromotion(string promotionId)
        {
            return _products.Where(x => x.PromotionId == promotionId).ToList();
        }
    }
}
