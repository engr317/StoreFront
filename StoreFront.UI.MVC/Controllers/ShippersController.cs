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
    public class ShippersController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(s => s.Balloon).Include(s => s.State);
            return View(shippers.ToList());
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            ViewBag.BalloonID = new SelectList(db.Balloons, "BalloonID", "SerialNo");
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipID,ShipVIA,FIrstName,LastName,Company,Address_1,Address_2,City,Country,StateID,ZipCode,Phone,Residential,Commercial,Notes,BalloonID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BalloonID = new SelectList(db.Balloons, "BalloonID", "SerialNo", shipper.BalloonID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", shipper.StateID);
            return View(shipper);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewBag.BalloonID = new SelectList(db.Balloons, "BalloonID", "SerialNo", shipper.BalloonID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", shipper.StateID);
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipID,ShipVIA,FIrstName,LastName,Company,Address_1,Address_2,City,Country,StateID,ZipCode,Phone,Residential,Commercial,Notes,BalloonID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BalloonID = new SelectList(db.Balloons, "BalloonID", "SerialNo", shipper.BalloonID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", shipper.StateID);
            return View(shipper);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipper shipper = db.Shippers.Find(id);
            db.Shippers.Remove(shipper);
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
