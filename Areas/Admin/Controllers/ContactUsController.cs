﻿using System;
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
    [Authorize]
    public class ContactUsController : Controller
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();

        // GET: Admin/ContactUs
        public ActionResult Index()
        {
            return View(db.ContactUs.ToList());
        }

        // GET: Admin/ContactUs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // GET: Admin/ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Phone,Facebook,Instagram,Twitter")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactU);
        }

        // GET: Admin/ContactUs/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: Admin/ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Phone,Facebook,Instagram,Twitter")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactU);
        }

        // GET: Admin/ContactUs/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: Admin/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            ContactU contactU = db.ContactUs.Find(id);
            db.ContactUs.Remove(contactU);
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
