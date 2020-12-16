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
    public class Billing_InformationController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Billing_Information
        public ActionResult Index()
        {
            var billing_Information = db.Billing_Information.Include(b => b.State);
            return View(billing_Information.ToList());
        }

        // GET: Billing_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing_Information billing_Information = db.Billing_Information.Find(id);
            if (billing_Information == null)
            {
                return HttpNotFound();
            }
            return View(billing_Information);
        }

        // GET: Billing_Information/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: Billing_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingID,Email,FirstName,LastName,Company,Address_1,Address_2,City,StateID,Zip,Phone")] Billing_Information billing_Information)
        {
            if (ModelState.IsValid)
            {
                db.Billing_Information.Add(billing_Information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", billing_Information.StateID);
            return View(billing_Information);
        }

        // GET: Billing_Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing_Information billing_Information = db.Billing_Information.Find(id);
            if (billing_Information == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", billing_Information.StateID);
            return View(billing_Information);
        }

        // POST: Billing_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingID,Email,FirstName,LastName,Company,Address_1,Address_2,City,StateID,Zip,Phone")] Billing_Information billing_Information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing_Information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", billing_Information.StateID);
            return View(billing_Information);
        }

        // GET: Billing_Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing_Information billing_Information = db.Billing_Information.Find(id);
            if (billing_Information == null)
            {
                return HttpNotFound();
            }
            return View(billing_Information);
        }

        // POST: Billing_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing_Information billing_Information = db.Billing_Information.Find(id);
            db.Billing_Information.Remove(billing_Information);
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
