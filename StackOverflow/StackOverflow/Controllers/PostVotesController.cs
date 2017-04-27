using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class PostVotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostVotes
        public ActionResult Index()
        {
            var postVotes = db.PostVotes.Include(p => p.Post).Include(p => p.User);
            return View(postVotes.ToList());
        }

        // GET: PostVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostVote postVote = db.PostVotes.Find(id);
            if (postVote == null)
            {
                return HttpNotFound();
            }
            return View(postVote);
        }

        // GET: PostVotes/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: PostVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoteValue,UserId,PostId")] PostVote postVote)
        {
            if (ModelState.IsValid)
            {
                db.PostVotes.Add(postVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postVote.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", postVote.UserId);
            return View(postVote);
        }

        // GET: PostVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostVote postVote = db.PostVotes.Find(id);
            if (postVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postVote.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", postVote.UserId);
            return View(postVote);
        }

        // POST: PostVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoteValue,UserId,PostId")] PostVote postVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postVote.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", postVote.UserId);
            return View(postVote);
        }

        // GET: PostVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostVote postVote = db.PostVotes.Find(id);
            if (postVote == null)
            {
                return HttpNotFound();
            }
            return View(postVote);
        }

        // POST: PostVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostVote postVote = db.PostVotes.Find(id);
            db.PostVotes.Remove(postVote);
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
