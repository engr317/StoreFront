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
    public class BalloonTypesController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: BalloonTypes
        public ActionResult Index()
        {
            return View(db.BalloonTypes.ToList());
        }

        // GET: BalloonTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonType balloonType = db.BalloonTypes.Find(id);
            if (balloonType == null)
            {
                return HttpNotFound();
            }
            return View(balloonType);
        }

        // GET: BalloonTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BalloonTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeID,IsMylar,IsLatex")] BalloonType balloonType)
        {
            if (ModelState.IsValid)
            {
                db.BalloonTypes.Add(balloonType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(balloonType);
        }

        // GET: BalloonTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonType balloonType = db.BalloonTypes.Find(id);
            if (balloonType == null)
            {
                return HttpNotFound();
            }
            return View(balloonType);
        }

        // POST: BalloonTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeID,IsMylar,IsLatex")] BalloonType balloonType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balloonType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(balloonType);
        }

        // GET: BalloonTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonType balloonType = db.BalloonTypes.Find(id);
            if (balloonType == null)
            {
                return HttpNotFound();
            }
            return View(balloonType);
        }

        // POST: BalloonTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BalloonType balloonType = db.BalloonTypes.Find(id);
            db.BalloonTypes.Remove(balloonType);
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
