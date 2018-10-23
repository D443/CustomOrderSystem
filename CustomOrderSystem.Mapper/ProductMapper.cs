using CustomOrderSystem.Entity;
using CustomOrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Mapper
{
   public static class ProductMapper
    {
        public static ProductModel MapToWM(Product entity)
        {
            return new ProductModel()
            {
                ID = entity.ProductId,
          
                ProductName=entity.ProductName,
                Price=entity.Price,
                Quantity=entity.Quantity,
                Barcode=entity.Barcode
                 

            };
        }

        public static List<ProductModel> MapToWM(List<Product> entity)
        {
           
            return entity.Select(x => new ProductModel()
            {
                ID = x.ProductId,
               
                Barcode = x.Barcode,
                Price = x.Price,
                Quantity = x.Quantity,
                ProductName = x.ProductName,

            }).ToList();
        }

        public static Product MapToEntity(ProductModel product)
        {
            return new Product()
            {
               ProductId=product.ID,
               ProductName=product.ProductName,
               Price=product.Price,
               Quantity=product.Quantity,
               Barcode=product.Barcode,
              
            };
        }

    }
}
