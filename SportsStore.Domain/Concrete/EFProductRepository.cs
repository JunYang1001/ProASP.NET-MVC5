using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
   public class EFProductRepository : IProductsRespository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }

        public Product DeleteProduct(int productID)
        {
            Product product = context.Products.Find(productID);
            if(product!=null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
              
            }
            return product;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
