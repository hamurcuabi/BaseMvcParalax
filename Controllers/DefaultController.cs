using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BaseMvcParalax.Helper;
using BaseMvcParalax.Models;


namespace BaseMvcParalax.Controllers
{
    public class DefaultController : MyController
    {
        private BaseMvcParalaxEntities db = new BaseMvcParalaxEntities();
        // GET: Default
        public ActionResult Index()
        {
            HomeAll homeAll=new HomeAll();
            homeAll.TopSliders = db.TopSliders.ToList();
            homeAll.Services = db.Services.ToList();
            homeAll.Projects = db.Projects.ToList();
            homeAll.SliderTexts = db.SliderTexts.ToList();
            homeAll.Sliders = db.Sliders.ToList();
            homeAll.ContactUs = db.ContactUs.FirstOrDefault();
            return View(homeAll);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Default");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail([Bind(Include = "message,email,subject,name")] Mail mail)
        {
            if (ModelState.IsValid)
            {
                
                db.Mails.Add(mail);
                db.SaveChanges();
                

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.live.com";
                client.EnableSsl = true;
                NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("", "");
             
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = SMTPUserInfo;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mail.Email);
                mailMessage.To.Add("emirogs1@gmail.com");
                mailMessage.Subject = "Hello There";
                mailMessage.Body = "Hello my friend!";
                client.Send(mailMessage);
                return RedirectToAction("Index", "ThankYou");

            }
            return RedirectToAction("Index", "Default");
        }
    }
}