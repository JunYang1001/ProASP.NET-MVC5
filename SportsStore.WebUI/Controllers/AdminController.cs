using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRespository respository;
        public AdminController(IProductsRespository productsRespository)
        {
            respository = productsRespository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(respository.Products);
        }
        public ViewResult Edit(int id)
        {
            Product product = respository.Products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                respository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

       
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    Product deletedProduct = respository.DeleteProduct(id);
        //    if (deletedProduct != null)
        //    {
        //        TempData["message"] = string.Format("{0} was deleted",
        //            deletedProduct.Name);
        //    }
        //    return RedirectToAction("Index");
        //}

    
    public ActionResult Delete(int id)
    {
        Product product = respository.DeleteProduct(id);
        if (product != null)
        {
            TempData["message"] = string.Format("{0} was delted", product.Name);

        }
        return RedirectToAction(nameof(Index));
    }
}
}