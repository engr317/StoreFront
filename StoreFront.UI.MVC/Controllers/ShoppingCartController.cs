using StoreFront.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count == 0)
            {                
                shoppingCart = new Dictionary<int, CartItemViewModel>();               
                ViewBag.Message = "There are no items in your cart.";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View(shoppingCart);
        }
    }
    
}