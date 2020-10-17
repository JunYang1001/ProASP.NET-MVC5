using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        private IProductsRespository respository;
        public NavController(IProductsRespository productsRespository)
        {
            respository = productsRespository;
        }

        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = respository.Products.Select(p => p.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}