using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace SportsStore.Domain.Entites
{
  public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please enrt a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enrt a description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Please enrt a product name")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enrt a category")]
        public string Category { get; set; }
    }
}
