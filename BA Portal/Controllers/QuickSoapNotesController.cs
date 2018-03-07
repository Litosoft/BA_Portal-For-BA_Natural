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
        private QuickSoapNotesDbContext db = new QuickSoapNotesDbContext();

        // GET: QuickSoapNotes
        public ActionResult Index()
        {
            return View(db.QuickSoapNotesDatabase.ToList());
        }

        // GET: QuickSoapNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNotes quickSoapNotes = db.QuickSoapNotesDatabase.Find(id);
            if (quickSoapNotes == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNotes);
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
        public ActionResult Create([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails,DateSeen,DateCompleted,CPTcode,NeedleSize,ElectroStimulation,TreatmentTime,PainScale,NeedlesPerformed,SField,OField,AField,PField,ICD10CM_Entry1,ICD10CM_Entry2,ICD10CM_Entry3,ICD10CM_Entry4,ICD10CM_Entry5")] QuickSoapNotes quickSoapNotes)
        {
            if (ModelState.IsValid)
            {
                db.QuickSoapNotesDatabase.Add(quickSoapNotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quickSoapNotes);
        }

        // GET: QuickSoapNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNotes quickSoapNotes = db.QuickSoapNotesDatabase.Find(id);
            if (quickSoapNotes == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNotes);
        }

        // POST: QuickSoapNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails,DateSeen,DateCompleted,CPTcode,NeedleSize,ElectroStimulation,TreatmentTime,PainScale,NeedlesPerformed,SField,OField,AField,PField,ICD10CM_Entry1,ICD10CM_Entry2,ICD10CM_Entry3,ICD10CM_Entry4,ICD10CM_Entry5")] QuickSoapNotes quickSoapNotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickSoapNotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quickSoapNotes);
        }

        // GET: QuickSoapNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNotes quickSoapNotes = db.QuickSoapNotesDatabase.Find(id);
            if (quickSoapNotes == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNotes);
        }

        // POST: QuickSoapNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickSoapNotes quickSoapNotes = db.QuickSoapNotesDatabase.Find(id);
            db.QuickSoapNotesDatabase.Remove(quickSoapNotes);
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
