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
    public class ProjectsController : Controller
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();

        // GET: Admin/Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Admin/Projects/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Admin/Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Header,Description,Sort,Visible,Tag")] Project project, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {

                    //Save image to file
                    var id = Guid.NewGuid();
                    var filename = image.FileName.Split('.')[0] + id+"_l.png";
                    var filePath = "/Images/" + filename;
                    image.SaveAs(Server.MapPath(filePath));
                    project.Image = filePath;
                    ImageHelper.SaveImage(Server.MapPath(filePath), 1170, 1170, "_l");
                }
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Admin/Projects/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Header,Description,Sort,Visible,Tag")] Project project, HttpPostedFileBase image)
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
                    ImageHelper.SaveImage(filePath, 1170, 1170, "_l");
                    project.Image = filePath;
                }
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Admin/Projects/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
