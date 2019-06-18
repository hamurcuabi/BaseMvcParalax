using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseMvcParalax;

namespace BaseMvcParalax.Areas.Admin.Controllers
{
    public class SliderTextsController : Controller
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();

        // GET: Admin/SliderTexts
        public ActionResult Index()
        {
            return View(db.SliderTexts.ToList());
        }

        // GET: Admin/SliderTexts/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderText sliderText = db.SliderTexts.Find(id);
            if (sliderText == null)
            {
                return HttpNotFound();
            }
            return View(sliderText);
        }

        // GET: Admin/SliderTexts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SliderTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MainText,Author,Sort,Visible")] SliderText sliderText)
        {
            if (ModelState.IsValid)
            {
                db.SliderTexts.Add(sliderText);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sliderText);
        }

        // GET: Admin/SliderTexts/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderText sliderText = db.SliderTexts.Find(id);
            if (sliderText == null)
            {
                return HttpNotFound();
            }
            return View(sliderText);
        }

        // POST: Admin/SliderTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MainText,Author,Sort,Visible")] SliderText sliderText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sliderText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sliderText);
        }

        // GET: Admin/SliderTexts/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderText sliderText = db.SliderTexts.Find(id);
            if (sliderText == null)
            {
                return HttpNotFound();
            }
            return View(sliderText);
        }

        // POST: Admin/SliderTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            SliderText sliderText = db.SliderTexts.Find(id);
            db.SliderTexts.Remove(sliderText);
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
