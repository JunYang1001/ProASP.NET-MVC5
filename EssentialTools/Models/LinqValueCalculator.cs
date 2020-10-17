using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace EssentialTools.Models {

    public class LinqValueCalculator : IValueCalculator
    {

        private IDiscountHelper discount;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discount = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Product> products) {

            return discount.ApplyDiscount(products.Sum(p => p.Price));
            //return products.Sum(p => p.Price);
        }
    }
}
