using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseMvcParalax;
using BaseMvcParalax.Helper;

namespace BaseMvcParalax.Areas.Admin.Controllers
{
    [Authorize]
    public class TopSlidersController : Controller
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();

        // GET: Admin/TopSliders
        public ActionResult Index()
        {
            return View(db.TopSliders.ToList());
        }

        // GET: Admin/TopSliders/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSlider topSlider = db.TopSliders.Find(id);
            if (topSlider == null)
            {
                return HttpNotFound();
            }
            return View(topSlider);
        }

        // GET: Admin/TopSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TopSliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,TopText,MiddleText,BottomText,Sort,Visible")] TopSlider topSlider, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {

                    //Save image to file
                    var id = Guid.NewGuid();
                    var filename = image.FileName.Split('.')[0] + id + "_l.png";
                    var filePath = "/Images/" + filename;
                    image.SaveAs(Server.MapPath(filePath));
                    topSlider.Image = filePath;
                    ImageHelper.SaveImage(Server.MapPath(filePath),1920,664,"_l");
                }
                db.TopSliders.Add(topSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topSlider);
        }

        // GET: Admin/TopSliders/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSlider topSlider = db.TopSliders.Find(id);
            if (topSlider == null)
            {
                return HttpNotFound();
            }
            return View(topSlider);
        }

        // POST: Admin/TopSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,TopText,MiddleText,BottomText,Sort,Visible")] TopSlider topSlider, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {

                    //Save image to file
                    var id = Guid.NewGuid();
                    var filename = image.FileName.Split('.')[0] + id + "." + image.FileName.Split('.')[1];
                    var filePath = "/Images/" + filename;
                    image.SaveAs(Server.MapPath(filePath));
                    topSlider.Image = filePath;
                    ImageHelper.SaveImage(Server.MapPath(filePath), 1920, 664, "_l");
                }
                db.Entry(topSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topSlider);
        }

        // GET: Admin/TopSliders/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSlider topSlider = db.TopSliders.Find(id);
            if (topSlider == null)
            {
                return HttpNotFound();
            }
            return View(topSlider);
        }

        // POST: Admin/TopSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            TopSlider topSlider = db.TopSliders.Find(id);
            db.TopSliders.Remove(topSlider);
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
