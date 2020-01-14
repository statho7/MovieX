using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieX.Models;

namespace MovieX.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Delete(string id)
        {
            var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(ApplicationUser appuser)
        {
            var user = db.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Edit(string id)
        {
            var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Edit(ApplicationUser appuser)
        {
            var user = db.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            //context.Entry(appuser).State = EntityState.Modified;
            user.FirstName = appuser.FirstName;
            user.LastName = appuser.LastName;
            user.Gender = appuser.Gender;
            user.FirstChoice = appuser.FirstChoice;
            user.SecondChoice = appuser.SecondChoice;
            user.ThirdChoice = appuser.ThirdChoice;
            user.Email = appuser.Email;

            db.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public ActionResult Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
