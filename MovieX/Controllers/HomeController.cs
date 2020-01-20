using MovieX.Models;
using MovieX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MovieX.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var movies = db.Movies.ToList();


            bool paid = false;

            if(User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                paid = UserManager.Users.SingleOrDefault(i => i.Id == userId).IsPaid == 1;
            }

            var viewModel = new HomeViewModel
            {
                Movies = movies,
                UserPaid = paid
            };

            return View(viewModel);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }



        public HomeController()
        {

        }
        public HomeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}