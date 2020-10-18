using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {

        private IProductsRespository respository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductsRespository productsRespository,IOrderProcessor proc)
        {
            respository = productsRespository;
            orderProcessor = proc;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart =cart, ReturnUrl = returnUrl });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = respository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if(product!=null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId,string returnUrl)
        {
            Product product = respository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product!=null)
            {
                cart.RemoveLine(product);
            }
           
            return RedirectToAction("Index", new { returnUrl });
        }


        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDtails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart,ShippingDtails shippingDtails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDtails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDtails);
            }
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }

    
}