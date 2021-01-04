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

        public ActionResult RemoveFromCart(int id)
        {
            //get the cart out of session and in to a local variable
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            //remove the item
            shoppingCart.Remove(id);

            //update the session cart to reflect the changes made
            Session["cart"] = shoppingCart;

            //setup a Viewbag Message if there are no items left in the cart
            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "You've deleted all the items in your cart.";
            }
            return RedirectToAction("Index");
        }

        //Add to Cart Step 8
        public ActionResult UpdateCart(int bookID, int qty)
        {
            //get the cart out of session and into a local variable
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            //target the correct item in teh car using the bookID for key and then we will change the quantity for that item
            shoppingCart[bookID].Qty = qty;

            //return the local shopping cart to the session variable and send the user back to the shopping cart index to see the results.
            Session["cart"] = shoppingCart;

            return RedirectToAction("Index");
        }
    }
    
}