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
    public class AccessoriesController : Controller
    {
        private BalloonsEntities db = new BalloonsEntities();

        // GET: Accessories
        public ActionResult Index()
        {
            return View(db.Accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessID,AccessName,AccessDesc")] Accessory accessory, HttpPostedFileBase AccessImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload

                string imageName = "noImage.png";
                //Check if the file uploaded is not null
                if (AccessImage != null)
                {
                    //Get the file name and save it to a variable
                    imageName = AccessImage.FileName;

                    //use the file name we got and retreive only the extension and save it to a variable
                    string ext = imageName.Substring(imageName.LastIndexOf("."));

                    //create a collection of valid extensions 
                    string[] goodExts = new string[] { ".jpeg", ".jpg", ".png", ".gif" };

                    //Compare our ext to the list
                    if (goodExts.Contains(ext.ToLower()))
                    {
                        //rename the file
                        //You could use other logic to create unique file names in this case you might
                        //use the bookTitle plust the date to create a unique name.
                        imageName = Guid.NewGuid() + ext;

                        //send the file to the webserver and save it
                        AccessImage.SaveAs(Server.MapPath("~/Content/assets/images/Accessories/" + imageName));

                    }
                    else //not a valid extension
                    {
                        //assign the value back to default
                        imageName = "noImage.png";
                    }
                }
                //No matter whether or not the file is legit, we are goin to update the database with the current value of the filename
                //Accessory.AccessImage = imageName;


                #endregion
                db.Accessories.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessory);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessID,AccessName,AccessDesc")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            db.Accessories.Remove(accessory);
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
