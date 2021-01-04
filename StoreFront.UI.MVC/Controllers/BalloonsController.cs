using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;
using System.Drawing;
using StoreFront.UI.MVC.Models;
using StoreFront.UI.MVC.Utilities;

namespace StoreFront.UI.MVC.Controllers
{
    public class BalloonsController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Balloons
        public ActionResult Index()
        {
            var balloons = db.Balloons.Include(b => b.Accessory).Include(b => b.BalloonStatu).Include(b => b.Distributor).Include(b => b.Seasonal).Include(b => b.Manufacturer).Include(b => b.BalloonType);
            return View(balloons.ToList());
        }

        // GET: Balloons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balloon balloon = db.Balloons.Find(id);
            if (balloon == null)
            {
                return HttpNotFound();
            }
            return View(balloon);
        }

        public ActionResult AddToCart(int qty, int balloonID)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                //session cart exsists - puts its items in the local version which is easier to work with
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
                //when we unbox a session object to its smaller more specific type, we use explicit casting
            }
            else
            {
                //if the sessioncartvariable yet does not exsist, we need to instantize it
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            } //after this if/else, we have a local cart we can add things to

            //find the product by its id (bookID)
            Balloon product = db.Balloons.Where(b => b.BalloonID == balloonID).FirstOrDefault();
            if (product == null)
            {
                //if we recieveda bad ID, we need to send them back to some page to try again or we could throw an error message
                return RedirectToAction("Index");

            }
            else
            {
                //if book is valid, then add the line item to the cart.
                CartItemViewModel item = new CartItemViewModel(qty, product);
                if (shoppingCart.ContainsKey(product.BalloonID))
                {
                    //here the product was already in the cart, we just needed to increase the quantity
                    shoppingCart[product.BalloonID].Qty += qty;
                }
                else
                {
                    //here the product is being added to the cart for the first time.
                    shoppingCart.Add(product.BalloonID, item);
                }

                //now we need to update the session version of the cart so we can maintain that info between request and response cycle
                Session["cart"] = shoppingCart; //no explicit casting is needed because this is a smaller container going into a larger container

                //confirmation message into a session variable so that it is available after the redirect
                Session["confirm"] = $"'{product.BalloonTitle}' (Quantity: {qty}) added to cart";
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

        // GET: Balloons/Create
        public ActionResult Create()
        {
            ViewBag.AccessID = new SelectList(db.Accessories, "AccessID", "AccessName");
            ViewBag.BalloonStatusID = new SelectList(db.BalloonStatus, "BalloonStatusID", "BalloonStatusName");
            ViewBag.DistributorsID = new SelectList(db.Distributors, "DIstributorsID", "DIstributorName");
            ViewBag.GenreID = new SelectList(db.Seasonals, "GenreID", "SeasonName");
            ViewBag.ManufactID = new SelectList(db.Manufacturers, "ManufactID", "CompanyName");
            ViewBag.TypeID = new SelectList(db.BalloonTypes, "TypeID", "TypeID");
            return View();
        }

        // POST: Balloons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BalloonID,SerialNo,BalloonTitle,Description,GenreID,Price,UnitsSold,ProdDate,DistributorsID,BalloonImg,IsCategoryFeature,BalloonStatusID,TypeID,Size,Color,ManufactID,AccessID")] Balloon balloon)
        {
            if (ModelState.IsValid)
            {
                db.Balloons.Add(balloon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessID = new SelectList(db.Accessories, "AccessID", "AccessName", balloon.AccessID);
            ViewBag.BalloonStatusID = new SelectList(db.BalloonStatus, "BalloonStatusID", "BalloonStatusName", balloon.BalloonStatusID);
            ViewBag.DistributorsID = new SelectList(db.Distributors, "DIstributorsID", "DIstributorName", balloon.DistributorsID);
            ViewBag.GenreID = new SelectList(db.Seasonals, "GenreID", "SeasonName", balloon.GenreID);
            ViewBag.ManufactID = new SelectList(db.Manufacturers, "ManufactID", "CompanyName", balloon.ManufactID);
            ViewBag.TypeID = new SelectList(db.BalloonTypes, "TypeID", "TypeID", balloon.TypeID);
            return View(balloon);
        }

        // GET: Balloons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balloon balloon = db.Balloons.Find(id);
            if (balloon == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessID = new SelectList(db.Accessories, "AccessID", "AccessName", balloon.AccessID);
            ViewBag.BalloonStatusID = new SelectList(db.BalloonStatus, "BalloonStatusID", "BalloonStatusName", balloon.BalloonStatusID);
            ViewBag.DistributorsID = new SelectList(db.Distributors, "DIstributorsID", "DIstributorName", balloon.DistributorsID);
            ViewBag.GenreID = new SelectList(db.Seasonals, "GenreID", "SeasonName", balloon.GenreID);
            ViewBag.ManufactID = new SelectList(db.Manufacturers, "ManufactID", "CompanyName", balloon.ManufactID);
            ViewBag.TypeID = new SelectList(db.BalloonTypes, "TypeID", "TypeID", balloon.TypeID);
            return View(balloon);
        }

        // POST: Balloons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BalloonID,SerialNo,BalloonTitle,Description,GenreID,Price,UnitsSold,ProdDate,DistributorsID,BalloonImg,IsCategoryFeature,BalloonStatusID,TypeID,Size,Color,ManufactID,AccessID")] Balloon balloon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balloon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessID = new SelectList(db.Accessories, "AccessID", "AccessName", balloon.AccessID);
            ViewBag.BalloonStatusID = new SelectList(db.BalloonStatus, "BalloonStatusID", "BalloonStatusName", balloon.BalloonStatusID);
            ViewBag.DistributorsID = new SelectList(db.Distributors, "DIstributorsID", "DIstributorName", balloon.DistributorsID);
            ViewBag.GenreID = new SelectList(db.Seasonals, "GenreID", "SeasonName", balloon.GenreID);
            ViewBag.ManufactID = new SelectList(db.Manufacturers, "ManufactID", "CompanyName", balloon.ManufactID);
            ViewBag.TypeID = new SelectList(db.BalloonTypes, "TypeID", "TypeID", balloon.TypeID);
            return View(balloon);
        }

        // GET: Balloons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balloon balloon = db.Balloons.Find(id);
            if (balloon == null)
            {
                return HttpNotFound();
            }
            return View(balloon);
        }

        // POST: Balloons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Balloon balloon = db.Balloons.Find(id);
            db.Balloons.Remove(balloon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
