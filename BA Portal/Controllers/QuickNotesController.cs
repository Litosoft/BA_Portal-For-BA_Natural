using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BA_Portal.Models;

namespace BA_Portal.Controllers
{
    public class QuickNotesController : Controller
    {
        private QuickNoteDbContext db = new QuickNoteDbContext();

        // GET: QuickNotes
        public ActionResult Index()
        {
            return View(db.SignatureDatabase.ToList());
        }

        // GET: QuickNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickNote quickNote = db.SignatureDatabase.Find(id);
            if (quickNote == null)
            {
                return HttpNotFound();
            }
            return View(quickNote);
        }

        // GET: QuickNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails")] QuickNote quickNote)
        {
            if (ModelState.IsValid)
            {
                db.SignatureDatabase.Add(quickNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quickNote);
        }

        // GET: QuickNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickNote quickNote = db.SignatureDatabase.Find(id);
            if (quickNote == null)
            {
                return HttpNotFound();
            }
            return View(quickNote);
        }

        // POST: QuickNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails")] QuickNote quickNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quickNote);
        }

        // GET: QuickNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickNote quickNote = db.SignatureDatabase.Find(id);
            if (quickNote == null)
            {
                return HttpNotFound();
            }
            return View(quickNote);
        }

        // POST: QuickNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickNote quickNote = db.SignatureDatabase.Find(id);
            db.SignatureDatabase.Remove(quickNote);
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
