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
    public class SubjectsController : Controller
    {
        private SubjectDbContext db = new SubjectDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            return View(db.SubjectDatabase.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DOB,Male,Female,Address,City,ZIP,PhoneHome,PhoneCell,Email,EmergencyContact,EmergencyContactPhone,EmergencyContactRelationship,ReferredBy,DateCreated,Allergy,AllergyDescription,HighBloodPressure,LowBloodPressure,HeartCondition,Diabetes,Anemia,HighCholesterol,Pacemaker,Epilepsy,Pregnant,Cancer,STD,Pain,PainDescription,Headache,HeadacheDescription,CommonCold,HighBloodPressureConcern,Stress,Depression,Sleep,Menstruation,Fertility,WeightControl,Other")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.SubjectDatabase.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DOB,Male,Female,Address,City,ZIP,PhoneHome,PhoneCell,Email,EmergencyContact,EmergencyContactPhone,EmergencyContactRelationship,ReferredBy,DateCreated,Allergy,AllergyDescription,HighBloodPressure,LowBloodPressure,HeartCondition,Diabetes,Anemia,HighCholesterol,Pacemaker,Epilepsy,Pregnant,Cancer,STD,Pain,PainDescription,Headache,HeadacheDescription,CommonCold,HighBloodPressureConcern,Stress,Depression,Sleep,Menstruation,Fertility,WeightControl,Other")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.SubjectDatabase.Find(id);
            db.SubjectDatabase.Remove(subject);
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

        public ActionResult ConsentFormModel()
        {
            return View();
        }
    }
}
