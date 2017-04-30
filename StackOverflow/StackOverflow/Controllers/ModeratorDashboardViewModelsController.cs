using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;
using StackOverflow.ViewModels;

namespace StackOverflow.Controllers
{
    public class ModeratorDashboardViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ModeratorDashboardViewModels
        public ActionResult Index()
        {
            var listOfPost = db.Posts.ToList();
            var listOfComments = db.Comments.ToList();
            var listofUsers = db.Users.ToList();

            var moderatorPageToDisplay = new ModeratorDashboardViewModel()
            { MyUsers = listofUsers, Comments = listOfComments, Posts = listOfPost };

            return View(moderatorPageToDisplay);
        }

        // GET: ModeratorDashboardViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeratorDashboardViewModel moderatorDashboardViewModel = db.ModeratorDashboardViewModels.Find(id);
            if (moderatorDashboardViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moderatorDashboardViewModel);
        }

        // GET: ModeratorDashboardViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeratorDashboardViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] ModeratorDashboardViewModel moderatorDashboardViewModel)
        {
            if (ModelState.IsValid)
            {
                db.ModeratorDashboardViewModels.Add(moderatorDashboardViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moderatorDashboardViewModel);
        }

        // GET: ModeratorDashboardViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeratorDashboardViewModel moderatorDashboardViewModel = db.ModeratorDashboardViewModels.Find(id);
            if (moderatorDashboardViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moderatorDashboardViewModel);
        }

        // POST: ModeratorDashboardViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] ModeratorDashboardViewModel moderatorDashboardViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moderatorDashboardViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moderatorDashboardViewModel);
        }

        // GET: ModeratorDashboardViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeratorDashboardViewModel moderatorDashboardViewModel = db.ModeratorDashboardViewModels.Find(id);
            if (moderatorDashboardViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moderatorDashboardViewModel);
        }

        // POST: ModeratorDashboardViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeratorDashboardViewModel moderatorDashboardViewModel = db.ModeratorDashboardViewModels.Find(id);
            db.ModeratorDashboardViewModels.Remove(moderatorDashboardViewModel);
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
