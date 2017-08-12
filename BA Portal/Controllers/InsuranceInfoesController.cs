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
    public class InsuranceInfoesController : Controller
    {
        private InsuranceInfoDbContext db = new InsuranceInfoDbContext();

        // GET: InsuranceInfoes
        public ActionResult Index()
        {
            return View(db.InsuranceInfoDatabase.ToList());
        }

        // GET: InsuranceInfoes/Details/5
        public ActionResult Details(int? id)
        {
            InsuranceInfo insuranceInfo = db.InsuranceInfoDatabase.Find(id);
            if (insuranceInfo == null)
            {
                return HttpNotFound();
            }
            return View(insuranceInfo);
        }

        public ActionResult PatientInsuranceIndex(int id = 0)
        {
            ViewBag.IDInsuranceInfoCreate = id;
            var DatabaseSelection = from x in db.InsuranceInfoDatabase where x.GroupingID == id select x;
            return View(DatabaseSelection.ToList());
        }

        // GET: InsuranceInfoes/Create
        public ActionResult Create(int id)
        {
            TempData["InsuranceCreationKey"] = id;
            return View();
        }

        // POST: InsuranceInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PatientName,DOB,PrimaryInsurer,InsuranceHolder,GroupNumber,IDNumber,PlanName")] InsuranceInfo insuranceInfo)
        {
            if (ModelState.IsValid)
            {
                insuranceInfo.GroupingID = (int)TempData["InsuranceCreationKey"];

                db.InsuranceInfoDatabase.Add(insuranceInfo);
                db.SaveChanges();
    
                return RedirectToAction("Index", "Subjects");
            }

            return View(insuranceInfo);
        }

        // GET: InsuranceInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            InsuranceInfo insuranceInfo = db.InsuranceInfoDatabase.Find(id);
            if (insuranceInfo == null)
            {
                return HttpNotFound();
            }
            return View(insuranceInfo);
        }

        // POST: InsuranceInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupingID,PatientName,DOB,PrimaryInsurer,InsuranceHolder,GroupNumber,IDNumber,PlanName")] InsuranceInfo insuranceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceInfo).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Subjects");
            }
            return View(insuranceInfo);
        }

        // GET: InsuranceInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            InsuranceInfo insuranceInfo = db.InsuranceInfoDatabase.Find(id);
            if (insuranceInfo == null)
            {
                return HttpNotFound();
            }
            return View(insuranceInfo);
        }

        // POST: InsuranceInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsuranceInfo insuranceInfo = db.InsuranceInfoDatabase.Find(id);
            db.InsuranceInfoDatabase.Remove(insuranceInfo);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Subjects");
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
