using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseMvcParalax.Helper;
using BaseMvcParalax.Models;

namespace BaseMvcParalax.Controllers
{
    public class ProjectController : MyController
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();
        // GET: Project
        public ActionResult Index(int id)
        {
            Projects projectsList=new Projects();
            int next=-1, before=-1, index=0;
            IEnumerable<Project> projects = db.Projects.ToList();
            Project current = projects.FirstOrDefault(p => p.Id == id);
            foreach (var item in projects)
            {
                if (item.Id == current.Id)
                {
                    next = index + 1;
                    before = index - 1;
                    break;
                }

                index++;
            }
            Project nextProject = projects.ElementAtOrDefault(next);
            Project beforeProject = projects.ElementAtOrDefault(before);
            projectsList.current = current;
            projectsList.next = nextProject;
            projectsList.before = beforeProject;

                
            return View(projectsList);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Project");
        }
    }
}