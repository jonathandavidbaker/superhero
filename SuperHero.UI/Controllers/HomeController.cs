using SuperHero.UI.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System;
using SuperHero.DATA.EF;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private SuperHeroEntities db = new SuperHeroEntities();

        [HttpGet]
        public ActionResult Index()
        {
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
                MailMessage m = new MailMessage("no-reply@DOMAIN.COM", "PERSONAL EMAIL ADDRESS", cvm.Subject, body);
                m.IsBodyHtml = true;
                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("DOMAIN MAIL SERVER");
                client.Credentials = new NetworkCredential("no-reply@DOMAIN.COM", "DOMAIN EMAIL PASSWORD");

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

        public ActionResult Calendar()
        {
            IEnumerable<CalendarViewModel> model = (from co in db.Courses
                                                    join cc in db.CourseCharacters on co.CourseID equals cc.CourseID
                                                    join ch in db.Characters on cc.CharacterID equals ch.CharacterID
                                                    join l in db.Locations on co.LocationID equals l.LocationID
                                                    select new CalendarViewModel
                                                    {
                                                        CourseID = co.CourseID,
                                                        Name = co.Name,
                                                        Description = co.Description,
                                                        Date = co.Date,
                                                        Address = l.Address,
                                                        City = l.City,
                                                        State = l.State,
                                                        Hero = ch.Name
                                                    }
                                                    
                                                 ).ToList();
            return View(model.OrderBy(m => m.Date));
        }


    }
}
