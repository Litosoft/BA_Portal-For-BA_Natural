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
    public class QuickSoapNotesController : Controller
    {
        private QuickSoapNoteDbContext db = new QuickSoapNoteDbContext();

        // GET: QuickSoapNotes
        public ActionResult Index()
        {
            return View(db.QuickSoapNoteDatabase.ToList());
        }

        // GET: QuickSoapNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNote quickSoapNote = db.QuickSoapNoteDatabase.Find(id);
            if (quickSoapNote == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNote);
        }

        // GET: QuickSoapNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickSoapNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails,DateSeen,CPTcode,NeedleSize,ElectroStimulation,TreatmentTime,PainScale,NeedlesPerformed,SField,OField,AField,PField,ICD10CM_Entry1,ICD10CM_Entry2,ICD10CM_Entry3,ICD10CM_Entry4,ICD10CM_Entry5")] QuickSoapNote quickSoapNote)
        {
            if (ModelState.IsValid)
            {
                db.QuickSoapNoteDatabase.Add(quickSoapNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quickSoapNote);
        }

        // GET: QuickSoapNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNote quickSoapNote = db.QuickSoapNoteDatabase.Find(id);
            if (quickSoapNote == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNote);
        }

        // POST: QuickSoapNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails,DateSeen,CPTcode,NeedleSize,ElectroStimulation,TreatmentTime,PainScale,NeedlesPerformed,SField,OField,AField,PField,ICD10CM_Entry1,ICD10CM_Entry2,ICD10CM_Entry3,ICD10CM_Entry4,ICD10CM_Entry5")] QuickSoapNote quickSoapNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickSoapNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quickSoapNote);
        }

        // GET: QuickSoapNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNote quickSoapNote = db.QuickSoapNoteDatabase.Find(id);
            if (quickSoapNote == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNote);
        }

        // POST: QuickSoapNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickSoapNote quickSoapNote = db.QuickSoapNoteDatabase.Find(id);
            db.QuickSoapNoteDatabase.Remove(quickSoapNote);
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
