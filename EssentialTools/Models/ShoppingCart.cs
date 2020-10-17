using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private readonly IValueCalculator _calcParam;

        public ShoppingCart(IValueCalculator calcParam)
        {
            _calcParam = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return _calcParam.ValueProducts(Products);
        }
    }
}