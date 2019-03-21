using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperHero.DATA.EF;

namespace SuperHero.UI.Controllers
{

    public class CharactersController : Controller
    {
        private SuperHeroEntities db = new SuperHeroEntities();

        // GET: Characters
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Characters.ToList());
        }

        // GET: Characters/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "CharacterID,Name,Alias,Description,Occupation,IsHero,IsActive")] Character character, HttpPostedFileBase heroImage)
        {
            //HttpPostedFileBase is the datatype for the file.  The name of the variable MUST match the name attribute of the input type=file in the UI 
            if (ModelState.IsValid)
            {
                //establish a variable for our default image
                string imageName = "noImage.png";
                //if a file was sent
                if (heroImage != null)
                {
                    //reassign the variable to the filename that was sent over
                    imageName = heroImage.FileName;

                    //create a variable for the extension
                    string ext = imageName.Substring(imageName.LastIndexOf('.'));

                    //create a list of valid extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //if the file extension is valid, assign a GUID as the name and concatenate the extension
                    string guid = new Guid().ToString();

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        imageName = guid + ext;
                        //save the file to the webserver
                        heroImage.SaveAs(Server.MapPath("~/Content/Images/Heroes/" + imageName));
                    }
                    else
                    {
                        imageName = "noImage.png";
                    }                    
                }
                character.CharacterImage = imageName;
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CharacterID,Name,Alias,Description,Occupation,IsHero,IsActive")] Character character, HttpPostedFileBase heroImage)
        {
            //HttpPostedFileBase is the datatype for the file.  The name of the variable MUST match the name attribute of the input type=file in the UI 
            if (ModelState.IsValid)
            {
                //establish a variable for our default image
                string imageName = "noImage.png";
                //if a file was sent
                if (heroImage != null)
                {
                    //reassign the variable to the filename that was sent over
                    imageName = heroImage.FileName;

                    //create a variable for the extension
                    string ext = imageName.Substring(imageName.LastIndexOf('.'));

                    //create a list of valid extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //if the file extension is valid, assign a GUID as the name and concatenate the extension
                    string guid = new Guid().ToString();

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        imageName = guid + ext;
                        //save the file to the webserver
                        heroImage.SaveAs(Server.MapPath("~/Content/Images/Heroes/" + imageName));
                    }
                    else
                    {
                        imageName = "noImage.png";
                    }
                }
                character.CharacterImage = imageName;
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(character);
        }
        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
