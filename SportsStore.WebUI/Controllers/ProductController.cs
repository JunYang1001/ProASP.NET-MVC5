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
        public ActionResult List(string category, int page=1)
        {
            if (category != null)
            {
                ProductsListViewModel model = new ProductsListViewModel
                {

                    Products = respository.Products
               .Where(p =>  p.Category == category)
               .OrderBy(p => p.ProductID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                   respository.Products.Count() : respository.Products.Where(e => e.Category == category).Count()
                    },
                    CurrnetCategory = category
                };
                return View(model);
            }
            else {
                ProductsListViewModel model = new ProductsListViewModel
                {

                    Products = respository.Products
                             
                              .OrderBy(p => p.ProductID)
                              .Skip((page - 1) * PageSize)
                              .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                                  respository.Products.Count() : respository.Products.Where(e => e.Category == category).Count()
                    },
                    CurrnetCategory = category
                };
                return View(model);
            }
               
           
           
        }
    }
}