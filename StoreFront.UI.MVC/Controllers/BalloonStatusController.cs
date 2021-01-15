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
    public class BalloonStatusController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: BalloonStatus
        public ActionResult Index()
        {
            return View(db.BalloonStatus.ToList());
        }

        // GET: BalloonStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonStatus balloonStatus = db.BalloonStatus.Find(id);
            if (balloonStatus == null)
            {
                return HttpNotFound();
            }
            return View(balloonStatus);
        }

        // GET: BalloonStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BalloonStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BalloonStatusID,BalloonStatusName,Notes")] BalloonStatus balloonStatus)
        {
            if (ModelState.IsValid)
            {
                db.BalloonStatus.Add(balloonStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(balloonStatus);
        }

        // GET: BalloonStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonStatus balloonStatus = db.BalloonStatus.Find(id);
            if (balloonStatus == null)
            {
                return HttpNotFound();
            }
            return View(balloonStatus);
        }

        // POST: BalloonStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BalloonStatusID,BalloonStatusName,Notes")] BalloonStatus balloonStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balloonStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(balloonStatus);
        }

        // GET: BalloonStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalloonStatus balloonStatus = db.BalloonStatus.Find(id);
            if (balloonStatus == null)
            {
                return HttpNotFound();
            }
            return View(balloonStatus);
        }

        // POST: BalloonStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BalloonStatus balloonStatus = db.BalloonStatus.Find(id);
            db.BalloonStatus.Remove(balloonStatus);
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
