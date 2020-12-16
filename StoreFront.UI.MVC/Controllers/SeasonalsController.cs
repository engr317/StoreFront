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
    public class SeasonalsController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Seasonals
        public ActionResult Index()
        {
            return View(db.Seasonals.ToList());
        }

        // GET: Seasonals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasonal seasonal = db.Seasonals.Find(id);
            if (seasonal == null)
            {
                return HttpNotFound();
            }
            return View(seasonal);
        }

        // GET: Seasonals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seasonals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID,SeasonName")] Seasonal seasonal)
        {
            if (ModelState.IsValid)
            {
                db.Seasonals.Add(seasonal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seasonal);
        }

        // GET: Seasonals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasonal seasonal = db.Seasonals.Find(id);
            if (seasonal == null)
            {
                return HttpNotFound();
            }
            return View(seasonal);
        }

        // POST: Seasonals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreID,SeasonName")] Seasonal seasonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seasonal);
        }

        // GET: Seasonals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasonal seasonal = db.Seasonals.Find(id);
            if (seasonal == null)
            {
                return HttpNotFound();
            }
            return View(seasonal);
        }

        // POST: Seasonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seasonal seasonal = db.Seasonals.Find(id);
            db.Seasonals.Remove(seasonal);
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
