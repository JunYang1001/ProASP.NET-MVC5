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
    }
}
