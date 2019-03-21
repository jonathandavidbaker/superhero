using SuperHero.UI.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"SuperHeroesInce Message from {cvm.Name} at {cvm.Email}: <br>{cvm.Message}";
                MailMessage m = new MailMessage("no-reply@jdbaker.net", "jon.david.baker@gmail.com", cvm.Subject, body);
                m.IsBodyHtml = true;
                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.jdbaker.net");
                client.Credentials = new NetworkCredential("no-reply@jdbaker.net", "pr$aM*Y*38V");

                try
                {
                    client.Send(m);     
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.StackTrace;
                }
            }
            return View("EmailConfirmation");
        }
    }
}
