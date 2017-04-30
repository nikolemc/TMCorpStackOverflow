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
    public class AuthenticatedUserQAViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuthenticatedUserQAViewModels
        public ActionResult Index()
        {
            var authenticatedUserQAViewModels = db.AuthenticatedUserQAViewModels.Include(a => a.User);
            return View(authenticatedUserQAViewModels.ToList());
        }

        // GET: AuthenticatedUserQAViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthenticatedUserQAViewModel authenticatedUserQAViewModel = db.AuthenticatedUserQAViewModels.Find(id);
            if (authenticatedUserQAViewModel == null)
            {
                return HttpNotFound();
            }
            return View(authenticatedUserQAViewModel);
        }

        // GET: AuthenticatedUserQAViewModels/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: AuthenticatedUserQAViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId")] AuthenticatedUserQAViewModel authenticatedUserQAViewModel)
        {
            if (ModelState.IsValid)
            {
                db.AuthenticatedUserQAViewModels.Add(authenticatedUserQAViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", authenticatedUserQAViewModel.UserId);
            return View(authenticatedUserQAViewModel);
        }

        // GET: AuthenticatedUserQAViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthenticatedUserQAViewModel authenticatedUserQAViewModel = db.AuthenticatedUserQAViewModels.Find(id);
            if (authenticatedUserQAViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", authenticatedUserQAViewModel.UserId);
            return View(authenticatedUserQAViewModel);
        }

        // POST: AuthenticatedUserQAViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId")] AuthenticatedUserQAViewModel authenticatedUserQAViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authenticatedUserQAViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", authenticatedUserQAViewModel.UserId);
            return View(authenticatedUserQAViewModel);
        }

        // GET: AuthenticatedUserQAViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthenticatedUserQAViewModel authenticatedUserQAViewModel = db.AuthenticatedUserQAViewModels.Find(id);
            if (authenticatedUserQAViewModel == null)
            {
                return HttpNotFound();
            }
            return View(authenticatedUserQAViewModel);
        }

        // POST: AuthenticatedUserQAViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthenticatedUserQAViewModel authenticatedUserQAViewModel = db.AuthenticatedUserQAViewModels.Find(id);
            db.AuthenticatedUserQAViewModels.Remove(authenticatedUserQAViewModel);
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
