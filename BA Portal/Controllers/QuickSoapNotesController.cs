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
        private QuickSoapNotesDbContext dbQuickSoap = new QuickSoapNotesDbContext();
        private SubjectDbContext dbSubjects = new SubjectDbContext();

        // GET: QuickSoapNotes
        public ActionResult Index(int id)
        {
            var QuickSoapSelected = from m in dbQuickSoap.QuickSoapNotesDatabase
                                  where m.UniqueID == id
                                  select m;

            return View(QuickSoapSelected.ToList());
        }

        // GET: QuickSoapNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickSoapNotes quickSoapNotes = dbQuickSoap.QuickSoapNotesDatabase.Find(id);
            if (quickSoapNotes == null)
            {
                return HttpNotFound();
            }
            return View(quickSoapNotes);
        }

        // GET: QuickSoapNotes/Create
        public ActionResult Create(int? id = -1)
        {
            if(id != -1)
            {
                var ClientsSelected = from m in dbSubjects.SubjectDatabase
                                      where m.ID == id
                                      select m;
                var subject = ClientsSelected.First();
                ViewBag.Name = subject.Name + " " + subject.LastName;
                ViewBag.UniqueId = subject.ID;
            }
            else
            {
                ViewBag.Name = "";
                ViewBag.UniqueId = "";
            }


            return View();
        }

        // POST: QuickSoapNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string TreatmentTime, string PainScale, string ICD10CM_Entry1, string ICD10CM_Entry2, string ICD10CM_Entry3, string ICD10CM_Entry4, string ICD10CM_Entry5, [Bind(Include = "ID,Name,UniqueID,ReturnDateRecommended,HerbalSupplement,OtherDetails,CPTcode,NeedleSize,ElectroStimulation,NeedlesPerformed,SField,OField,AField,PField")] QuickSoapNotes quickSoapNotes)
        {
            if (ModelState.IsValid)
            {
                quickSoapNotes.DateSeen = DateTime.Now.ToShortDateString();
                quickSoapNotes.DateCompleted = DateTime.Now;
                dbQuickSoap.QuickSoapNotesDatabase.Add(quickSoapNotes);
                dbQuickSoap.SaveChanges();

                // Need to change redirect
                return RedirectToAction("Index");
                return RedirectToAction("Index", "QuickSoapNotes", new { id = quickSoapNotes.UniqueID });
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
            QuickSoapNotes quickSoapNotes = dbQuickSoap.QuickSoapNotesDatabase.Find(id);
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
                dbQuickSoap.Entry(quickSoapNotes).State = EntityState.Modified;
                dbQuickSoap.SaveChanges();
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
            QuickSoapNotes quickSoapNotes = dbQuickSoap.QuickSoapNotesDatabase.Find(id);
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
            QuickSoapNotes quickSoapNotes = dbQuickSoap.QuickSoapNotesDatabase.Find(id);
            dbQuickSoap.QuickSoapNotesDatabase.Remove(quickSoapNotes);
            dbQuickSoap.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbQuickSoap.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
