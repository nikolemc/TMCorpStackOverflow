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
    public class SearchViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SearchViewModels
        public ActionResult Index()
        {


            return View();
        }

        // GET: SearchViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchViewModel searchViewModel = db.SearchViewModels.Find(id);
            if (searchViewModel == null)
            {
                return HttpNotFound();
            }
            return View(searchViewModel);
        }

        // GET: SearchViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,searchKeyWord")] SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                db.SearchViewModels.Add(searchViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(searchViewModel);
        }

        // GET: SearchViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchViewModel searchViewModel = db.SearchViewModels.Find(id);
            if (searchViewModel == null)
            {
                return HttpNotFound();
            }
            return View(searchViewModel);
        }

        // POST: SearchViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,searchKeyWord")] SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchViewModel);
        }

        // GET: SearchViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchViewModel searchViewModel = db.SearchViewModels.Find(id);
            if (searchViewModel == null)
            {
                return HttpNotFound();
            }
            return View(searchViewModel);
        }

        // POST: SearchViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SearchViewModel searchViewModel = db.SearchViewModels.Find(id);
            db.SearchViewModels.Remove(searchViewModel);
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
