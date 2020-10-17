using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRespository respository;
        public int PageSize = 4;
        public ProductController(IProductsRespository productsRespository)
        {
            this.respository = productsRespository;
        }
        // GET: Product
        public ActionResult List(int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = respository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = respository.Products.Count()
                }
            };
            return View(model); 
        }
    }
}