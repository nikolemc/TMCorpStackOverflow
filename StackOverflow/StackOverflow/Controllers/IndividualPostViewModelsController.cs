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
    public class IndividualPostViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IndividualPostViewModels
        public ActionResult Index(int postId)
        {
            var post = db.Posts.Find(postId);
            var listOfComments = db.Comments.Where(w => w.PostId == postId).Include(c => c.User).ToList();

            var postPageToDisplay = new IndividualPostViewModel() { Post = post, Comments = listOfComments };

            return View(postPageToDisplay);
        }

        // GET: IndividualPostViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPostViewModel individualPostViewModel = db.IndividualPostViewModels.Find(id);
            if (individualPostViewModel == null)
            {
                return HttpNotFound();
            }
            return View(individualPostViewModel);
        }

        // GET: IndividualPostViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndividualPostViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] IndividualPostViewModel individualPostViewModel)
        {
            if (ModelState.IsValid)
            {
                db.IndividualPostViewModels.Add(individualPostViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(individualPostViewModel);
        }

        // GET: IndividualPostViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPostViewModel individualPostViewModel = db.IndividualPostViewModels.Find(id);
            if (individualPostViewModel == null)
            {
                return HttpNotFound();
            }
            return View(individualPostViewModel);
        }

        // POST: IndividualPostViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] IndividualPostViewModel individualPostViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualPostViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(individualPostViewModel);
        }

        // GET: IndividualPostViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPostViewModel individualPostViewModel = db.IndividualPostViewModels.Find(id);
            if (individualPostViewModel == null)
            {
                return HttpNotFound();
            }
            return View(individualPostViewModel);
        }

        // POST: IndividualPostViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndividualPostViewModel individualPostViewModel = db.IndividualPostViewModels.Find(id);
            db.IndividualPostViewModels.Remove(individualPostViewModel);
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
