using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StackOverflow.Models;
using StackOverflow.ViewModels;

namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.IsAdministrator = HttpContext.User.IsInRole("administrator");
                ViewBag.IsGeneralUser = HttpContext.User.IsInRole("generalUser");
            }
            var post = db.Posts.Include(i => i.Votes).Include(c => c.User).ToList();
            var postPageToDisplay = new HomePageViewModel() { Post = post};
            return View(postPageToDisplay);
        }

        [Authorize(Roles = "generalUser")]

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
    }
}