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
    public class InsuranceVerificationsController : Controller
    {
        private InsuranceVerificationDbContext db = new InsuranceVerificationDbContext();

        // GET: InsuranceVerifications
        public ActionResult Index()
        {
            return View(db.InsuranceVerificationDatabase.ToList());
        }

        public ActionResult PatientInsuranceIndex(int id = -1)
        {
            ViewBag.IDInsuranceInfoCreate = id;
            return View(db.InsuranceVerificationDatabase.ToList());
        }

        // GET: InsuranceVerifications/Details/5
        public ActionResult Details(int? id)
        {
            InsuranceVerification insuranceVerification = db.InsuranceVerificationDatabase.Find(id);
            if (insuranceVerification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceVerification);
        }

        // GET: InsuranceVerifications/Create
        public ActionResult Create(int id)
        {
            TempData["InsuranceCreationKey2"] = id;
            return View();
        }

        // POST: InsuranceVerifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string InsuranceCompany1, [Bind(Include = "ID,GroupingID,OutOfNetworkCoverage,NumberOfTreatment,Limitations,Deductibles,DeductiblesMet,CoInsurance,NoCoInsurance,OutOfPocket,OutOfPocketMet")] InsuranceVerification insuranceVerification)
        {
            if (ModelState.IsValid)
            {
                insuranceVerification.GroupingID = (int)TempData["InsuranceCreationKey2"];
                insuranceVerification.InsuranceCompany = InsuranceCompany1;
                db.InsuranceVerificationDatabase.Add(insuranceVerification);
                db.SaveChanges();
                //return RedirectToAction("Index"); 
                return RedirectToAction("PatientInsuranceIndex" + "/" + insuranceVerification.GroupingID); 
            }

            return View(insuranceVerification);
        }

        // GET: InsuranceVerifications/Edit/5
        public ActionResult Edit(int? id)
        {
            InsuranceVerification insuranceVerification = db.InsuranceVerificationDatabase.Find(id);
            if (insuranceVerification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceVerification);
        }

        // POST: InsuranceVerifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupingID,OutOfNetworkCoverage,NumberOfTreatment,Limitations,Deductibles,DeductiblesMet,CoInsurance,NoCoInsurance,OutOfPocket,OutOfPocketMet,InsuranceCompany")] InsuranceVerification insuranceVerification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceVerification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuranceVerification);
        }

        // GET: InsuranceVerifications/Delete/5
        public ActionResult Delete(int? id)
        {
            InsuranceVerification insuranceVerification = db.InsuranceVerificationDatabase.Find(id);
            if (insuranceVerification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceVerification);
        }

        // POST: InsuranceVerifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsuranceVerification insuranceVerification = db.InsuranceVerificationDatabase.Find(id);
            db.InsuranceVerificationDatabase.Remove(insuranceVerification);
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
