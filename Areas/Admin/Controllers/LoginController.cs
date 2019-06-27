using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BaseMvcParalax.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();
        
        [HttpPost]
        public ActionResult Index(Member member)
        {
            Member m = db.Members.FirstOrDefault(p => p.UserName == member.UserName && p.Password == member.Password);
            if (m != null)
            {
                FormsAuthentication.SetAuthCookie(m.Id.ToString(), false);
                ViewBag.mesaj = "";
                return RedirectToAction("Index", "TopSliders");
            }
            else
            {
                ViewBag.mesaj = "<p class='btn btn-danger'>Hatalı Grişi</p>";
                return View();
            }

           
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}