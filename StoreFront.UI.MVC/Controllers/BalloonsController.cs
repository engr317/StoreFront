using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    public class BalloonsController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Balloons
        public ActionResult Index()
        {
            var balloons = db.Balloons.Include(b => b.Accessory).Include(b => b.BalloonStatu).Include(b => b.Distributor).Include(b => b.Seasonal).Include(b => b.Manufacturer).Include(b => b.Type);
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

        // GET: Balloons/Create
        public ActionResult Create()
        {
            ViewBag.AccessID = new SelectList(db.Accessories, "AccessID", "AccessName");
            ViewBag.BalloonStatusID = new SelectList(db.BalloonStatus, "BalloonStatusID", "BalloonStatusName");
            ViewBag.DistributorsID = new SelectList(db.Distributors, "DIstributorsID", "DIstributorName");
            ViewBag.GenreID = new SelectList(db.Seasonals, "GenreID", "SeasonName");
            ViewBag.ManufactID = new SelectList(db.Manufacturers, "ManufactID", "CompanyName");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeID");
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
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeID", balloon.TypeID);
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
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeID", balloon.TypeID);
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
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeID", balloon.TypeID);
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
