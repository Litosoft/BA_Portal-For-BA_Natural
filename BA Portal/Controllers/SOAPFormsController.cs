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
    public class SOAPFormsController : Controller
    {
        private SOAPFormDbContext db = new SOAPFormDbContext();

        // GET: SOAPForms
        public ActionResult Index()
        {
            return View(db.SOAPFormDatabase.ToList());
        }

        // GET: SOAPForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAPForm sOAPForm = db.SOAPFormDatabase.Find(id);
            if (sOAPForm == null)
            {
                return HttpNotFound();
            }
            return View(sOAPForm);
        }

        // GET: SOAPForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOAPForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PractionerName,PractionerLicenseNumber,PatientName,BP,BodyTemperature,SubjectiveObjectiveNotes,DateFilledIn,TimeTreatmentStarted,TimeTreatmentEnded,SymptomsGeneral,PresentingProblems,SymptomsChillsFeverNotes,SymptomsChillsFeverNone,SymptomsChillsFeverSubjective,SymptomsChillsFeverObjective,SymptomsPerspiratonNotes,SymptomsPerspiratonNone,SymptomsPerspiratonSubjective,SymptomsPerspiratonObjective,SymptomsUrinationNotes,SymptomsUrinationNormal,SymptomsUrinationSubjective,SymptomsUrinationObjective,SymptomsHeadacheBodyacheNotes,SymptomsHeadacheBodyacheNone,SymptomsRespirationNotes,SymptomsRespirationNormal,SymptomsRespirationSubjective,SymptomsRespirationObjective,SymptomsSleepEnergyNotes,SymptomsSleepEnergyNormal,SymptomsSleepEnergySubjective,SymptomsSleepEnergyObjective,SymptomsReproductiveNotes,SymptomsReproductiveNormal,SymptomsMentalEmotionalNotes,SymptomsMentalEmotionalNormal,SymptomsMentalEmotionalSubjective,SymptomsMentalEmotionalObjective,SymptomsEarsEyesTeethGumsNotes,SymptomsEarsEyesTeethGumsNormal,SymptomsEarsEyesTeethGumsSubjective,SymptomsEarsEyesTeethGumsObjective,SymptomsAppetiteDigestionDefecationNotes,SymptomsAppetiteDigestionDefecationNormal,SymptomsAppetiteDigestionDefecationSubjective,SymptomsAppetiteDigestionDefecationObjective,SymptomsPalpitationDizzinessNumbnessNotes,SymptomsPalpitationDizzinessNumbnessNone,SymptomsPalpitationDizzinessNumbnessSubjective,SymptomsPalpitationDizzinessNumbnessObjective,TongueBodyColor,TongueCoating,CoatColoration,CoatRooting,PulseRight,PulseLeft,AssessmentandDiagnosis,PlanofTreatment,CleanNeedSet,NeedlingSet1ElectricalStimulation,NeedlingSet1TuiNa,NeedlingSet1CuppingTherapy,NeedlingSet2ElectricalStimulation,NeedlingSet2TuiNa,NeedlingSet2CuppingTherapy,NeedlingSet3ElectricalStimulation,NeedlingSet3TuiNa,NeedlingSet3CuppingTherapy,NeedlingSet4ElectricalStimulation,NeedlingSet4TuiNa,NeedlingSet4CuppingTherapy,NeedlingSet5ElectricalStimulation,NeedlingSet5TuiNa,NeedlingSet5CuppingTherapy,NeedlingSet6ElectricalStimulation,NeedlingSet6TuiNa,NeedlingSet6CuppingTherapy,HerbalFormulaId1,HerbalFormulaId1Directions,HerbalFormulaId2,HerbalFormulaId2Directions,HerbalFormulaId3,HerbalFormulaId3Directions,PostTreatmentAssessment,Recomendations")] SOAPForm sOAPForm)
        {
            if (ModelState.IsValid)
            {
                db.SOAPFormDatabase.Add(sOAPForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOAPForm);
        }

        // GET: SOAPForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAPForm sOAPForm = db.SOAPFormDatabase.Find(id);
            if (sOAPForm == null)
            {
                return HttpNotFound();
            }
            return View(sOAPForm);
        }

        // POST: SOAPForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PractionerName,PractionerLicenseNumber,PatientName,BP,BodyTemperature,SubjectiveObjectiveNotes,DateFilledIn,TimeTreatmentStarted,TimeTreatmentEnded,SymptomsGeneral,PresentingProblems,SymptomsChillsFeverNotes,SymptomsChillsFeverNone,SymptomsChillsFeverSubjective,SymptomsChillsFeverObjective,SymptomsPerspiratonNotes,SymptomsPerspiratonNone,SymptomsPerspiratonSubjective,SymptomsPerspiratonObjective,SymptomsUrinationNotes,SymptomsUrinationNormal,SymptomsUrinationSubjective,SymptomsUrinationObjective,SymptomsHeadacheBodyacheNotes,SymptomsHeadacheBodyacheNone,SymptomsRespirationNotes,SymptomsRespirationNormal,SymptomsRespirationSubjective,SymptomsRespirationObjective,SymptomsSleepEnergyNotes,SymptomsSleepEnergyNormal,SymptomsSleepEnergySubjective,SymptomsSleepEnergyObjective,SymptomsReproductiveNotes,SymptomsReproductiveNormal,SymptomsMentalEmotionalNotes,SymptomsMentalEmotionalNormal,SymptomsMentalEmotionalSubjective,SymptomsMentalEmotionalObjective,SymptomsEarsEyesTeethGumsNotes,SymptomsEarsEyesTeethGumsNormal,SymptomsEarsEyesTeethGumsSubjective,SymptomsEarsEyesTeethGumsObjective,SymptomsAppetiteDigestionDefecationNotes,SymptomsAppetiteDigestionDefecationNormal,SymptomsAppetiteDigestionDefecationSubjective,SymptomsAppetiteDigestionDefecationObjective,SymptomsPalpitationDizzinessNumbnessNotes,SymptomsPalpitationDizzinessNumbnessNone,SymptomsPalpitationDizzinessNumbnessSubjective,SymptomsPalpitationDizzinessNumbnessObjective,TongueBodyColor,TongueCoating,CoatColoration,CoatRooting,PulseRight,PulseLeft,AssessmentandDiagnosis,PlanofTreatment,CleanNeedSet,NeedlingSet1ElectricalStimulation,NeedlingSet1TuiNa,NeedlingSet1CuppingTherapy,NeedlingSet2ElectricalStimulation,NeedlingSet2TuiNa,NeedlingSet2CuppingTherapy,NeedlingSet3ElectricalStimulation,NeedlingSet3TuiNa,NeedlingSet3CuppingTherapy,NeedlingSet4ElectricalStimulation,NeedlingSet4TuiNa,NeedlingSet4CuppingTherapy,NeedlingSet5ElectricalStimulation,NeedlingSet5TuiNa,NeedlingSet5CuppingTherapy,NeedlingSet6ElectricalStimulation,NeedlingSet6TuiNa,NeedlingSet6CuppingTherapy,HerbalFormulaId1,HerbalFormulaId1Directions,HerbalFormulaId2,HerbalFormulaId2Directions,HerbalFormulaId3,HerbalFormulaId3Directions,PostTreatmentAssessment,Recomendations")] SOAPForm sOAPForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOAPForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOAPForm);
        }

        // GET: SOAPForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAPForm sOAPForm = db.SOAPFormDatabase.Find(id);
            if (sOAPForm == null)
            {
                return HttpNotFound();
            }
            return View(sOAPForm);
        }

        // POST: SOAPForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOAPForm sOAPForm = db.SOAPFormDatabase.Find(id);
            db.SOAPFormDatabase.Remove(sOAPForm);
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
