using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;
using Microsoft.AspNet.Identity;

namespace StackOverflow.Controllers
{
    public class CommentVotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Vote(int id, int voteValue)
        {
            
            db.CommentVotes.Add(new CommentVote { CommentId = id, IsAllowedToVote = true, UserId = User.Identity.GetUserId(), VoteValue = voteValue });
            db.SaveChanges();
            var comment = db.Comments.Include(i => i.Votes).FirstOrDefault(f => f.Id == id);

            return PartialView("_CommentVotePartial", comment);
        }




        // GET: CommentVotes
        public ActionResult Index()
        {
            var commentVotes = db.CommentVotes.Include(c => c.Comment).Include(c => c.User);
            return View(commentVotes.ToList());
        }

        // GET: CommentVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentVote commentVote = db.CommentVotes.Find(id);
            if (commentVote == null)
            {
                return HttpNotFound();
            }
            return View(commentVote);
        }

        // GET: CommentVotes/Create
        public ActionResult Create()
        {
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: CommentVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoteValue,UserId,CommentId")] CommentVote commentVote)
        {
            if (ModelState.IsValid)
            {
                db.CommentVotes.Add(commentVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Title", commentVote.CommentId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", commentVote.UserId);
            return View(commentVote);
        }

        // GET: CommentVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentVote commentVote = db.CommentVotes.Find(id);
            if (commentVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Title", commentVote.CommentId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", commentVote.UserId);
            return View(commentVote);
        }

        // POST: CommentVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoteValue,UserId,CommentId")] CommentVote commentVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Title", commentVote.CommentId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", commentVote.UserId);
            return View(commentVote);
        }

        // GET: CommentVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentVote commentVote = db.CommentVotes.Find(id);
            if (commentVote == null)
            {
                return HttpNotFound();
            }
            return View(commentVote);
        }

        // POST: CommentVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentVote commentVote = db.CommentVotes.Find(id);
            db.CommentVotes.Remove(commentVote);
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
