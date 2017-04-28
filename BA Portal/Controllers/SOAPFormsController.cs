using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BA_Portal.Models;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;

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

        public ActionResult IncompleteSoapFormRedirecttocreatePDF(int id)
        {

            TempData["SOAPFormID"] = id;
            return RedirectToAction("GetDoctorSignatureSOAP", "Signatures");
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

        public ActionResult PatientSOAPIndex(int id)
        {
            ViewBag.ID = id;
            return View(db.SOAPFormDatabase.ToList());
        }

        // POST: SOAPForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string[] PulseRight1, string[] PulseLeft1, string[] TongueBodyShape1, string[] TongueBodyColor1, string[] TongueCoating1, string[] CoatColoration1, string[] CoatRooting1, string[] Set1Points, string[] Set2Points, string[] Set3Points, string[] Set4Points, string[] Set5Points, string[] Set6Points, [Bind(Include = "ID,PractionerName,PractionerLicenseNumber,ThirstNormal,ThirstSubjective,ThirstObjective,TimeTreatmentStarts,TimeTreatmentEnds,TreatmentPrinciples,ThirstNotes,OtherPhysicalExamsNotes,PatientName,BP,BodyTemperature,SubjectiveObjectiveNotes,DateFilledIn,SymptomsGeneral,PresentingProblems,SymptomsChillsFeverNotes,SymptomsChillsFeverNone,SymptomsChillsFeverSubjective,SymptomsChillsFeverObjective,SymptomsPerspiratonNotes,SymptomsPerspiratonNone,SymptomsPerspiratonSubjective,SymptomsPerspiratonObjective,SymptomsUrinationNotes,SymptomsUrinationNormal,SymptomsUrinationSubjective,SymptomsUrinationObjective,SymptomsHeadacheBodyacheNotes,SymptomsHeadacheBodyacheNone,SymptomsRespirationNotes,SymptomsRespirationNormal,SymptomsRespirationSubjective,SymptomsRespirationObjective,SymptomsSleepEnergyNotes,SymptomsSleepEnergyNormal,SymptomsSleepEnergySubjective,SymptomsSleepEnergyObjective,SymptomsReproductiveNotes,SymptomsReproductiveNormal,SymptomsMentalEmotionalNotes,SymptomsMentalEmotionalNormal,SymptomsMentalEmotionalSubjective,SymptomsMentalEmotionalObjective,SymptomsEarsEyesTeethGumsNotes,SymptomsEarsEyesTeethGumsNormal,SymptomsEarsEyesTeethGumsSubjective,SymptomsEarsEyesTeethGumsObjective,SymptomsAppetiteDigestionDefecationNotes,SymptomsAppetiteDigestionDefecationNormal,SymptomsAppetiteDigestionDefecationSubjective,SymptomsAppetiteDigestionDefecationObjective,SymptomsPalpitationDizzinessNumbnessNotes,SymptomsPalpitationDizzinessNumbnessNone,SymptomsPalpitationDizzinessNumbnessSubjective,SymptomsPalpitationDizzinessNumbnessObjective,AssessmentandDiagnosis,PlanofTreatment,CleanNeedSet,NeedlingSet1ElectricalStimulation,NeedlingSet1TuiNa,NeedlingSet1CuppingTherapy,NeedlingSet2ElectricalStimulation,NeedlingSet2TuiNa,NeedlingSet2CuppingTherapy,NeedlingSet3ElectricalStimulation,NeedlingSet3TuiNa,NeedlingSet3CuppingTherapy,NeedlingSet4ElectricalStimulation,NeedlingSet4TuiNa,NeedlingSet4CuppingTherapy,NeedlingSet5ElectricalStimulation,NeedlingSet5TuiNa,NeedlingSet5CuppingTherapy,NeedlingSet6ElectricalStimulation,NeedlingSet6TuiNa,NeedlingSet6CuppingTherapy,HerbalFormulaId1,HerbalFormulaId1Directions,HerbalFormulaId2,HerbalFormulaId2Directions,HerbalFormulaId3,HerbalFormulaId3Directions,PostTreatmentAssessment,Recomendations")] SOAPForm sOAPForm)
        {

            //notes
            //TimeTreatmentStarted,TimeTreatmentEnded


            if (ModelState.IsValid)
            {

                {

                    //redundant
                    sOAPForm.NeedlingSet1 = new string[5];
                    sOAPForm.NeedlingSet2 = new string[5];
                    sOAPForm.NeedlingSet3 = new string[5];
                    sOAPForm.NeedlingSet4 = new string[5];
                    sOAPForm.NeedlingSet5 = new string[5];
                    sOAPForm.NeedlingSet6 = new string[5];
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    ///?? acts as if null then ...
                    sOAPForm.NeedlingSet1asString = null;
                    foreach (var item in Set1Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet1asString == null)
                        {
                            sOAPForm.NeedlingSet1asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet1asString = sOAPForm.NeedlingSet1asString + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.NeedlingSet2asString = null;
                    foreach (var item in Set2Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet2asString == null)
                        {
                            sOAPForm.NeedlingSet2asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet2asString = sOAPForm.NeedlingSet2asString + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.NeedlingSet3asString = null;
                    foreach (var item in Set3Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet3asString == null)
                        {
                            sOAPForm.NeedlingSet3asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet3asString = sOAPForm.NeedlingSet3asString + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.NeedlingSet4asString = null;
                    foreach (var item in Set4Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet4asString == null)
                        {
                            sOAPForm.NeedlingSet4asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet4asString = sOAPForm.NeedlingSet4asString + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.NeedlingSet5asString = null;
                    foreach (var item in Set5Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet5asString == null)
                        {
                            sOAPForm.NeedlingSet5asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet5asString = sOAPForm.NeedlingSet5asString + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.NeedlingSet6asString = null;
                    foreach (var item in Set6Points ?? new string[0])
                    {
                        if (sOAPForm.NeedlingSet6asString == null)
                        {
                            sOAPForm.NeedlingSet6asString = item;
                        }
                        else
                        {
                            sOAPForm.NeedlingSet6asString = sOAPForm.NeedlingSet6asString + ", " + item;
                        }

                    }
                }
                // END NEEDLING SETS


                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.TongueBodyShape = null;
                    foreach (var item in TongueBodyShape1 ?? new string[0])
                    {
                        if (sOAPForm.TongueBodyShape == null)
                        {
                            sOAPForm.TongueBodyShape = item;
                        }
                        else
                        {
                            sOAPForm.TongueBodyShape = sOAPForm.TongueBodyShape + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.TongueBodyColor = null;
                    foreach (var item in TongueBodyColor1 ?? new string[0])
                    {
                        if (sOAPForm.TongueBodyColor == null)
                        {
                            sOAPForm.TongueBodyColor = item;
                        }
                        else
                        {
                            sOAPForm.TongueBodyColor = sOAPForm.TongueBodyColor + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.TongueCoating = null;
                    foreach (var item in TongueCoating1 ?? new string[0])
                    {
                        if (sOAPForm.TongueCoating == null)
                        {
                            sOAPForm.TongueCoating = item;
                        }
                        else
                        {
                            sOAPForm.TongueCoating = sOAPForm.TongueCoating + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.CoatColoration = null;
                    foreach (var item in CoatColoration1 ?? new string[0])
                    {
                        if (sOAPForm.CoatColoration == null)
                        {
                            sOAPForm.CoatColoration = item;
                        }
                        else
                        {
                            sOAPForm.CoatColoration = sOAPForm.CoatColoration + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.CoatRooting = null;
                    foreach (var item in CoatRooting1 ?? new string[0])
                    {
                        if (sOAPForm.CoatRooting == null)
                        {
                            sOAPForm.CoatRooting = item;
                        }
                        else
                        {
                            sOAPForm.CoatRooting = sOAPForm.CoatRooting + ", " + item;
                        }

                    }
                }

                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.PulseRight = null;
                    foreach (var item in PulseRight1 ?? new string[0])
                    {
                        if (sOAPForm.PulseRight == null)
                        {
                            sOAPForm.PulseRight = item;
                        }
                        else
                        {
                            sOAPForm.PulseRight = sOAPForm.PulseRight + ", " + item;
                        }

                    }
                }
                //iterate through multi select, which returns a string[].
                //set to null so that there is no comma befor first item is printed.
                {
                    ///use this scheme for all other multiselects
                    sOAPForm.PulseLeft = null;
                    foreach (var item in PulseLeft1 ?? new string[0])
                    {
                        if (sOAPForm.PulseLeft == null)
                        {
                            sOAPForm.PulseLeft = item;
                        }
                        else
                        {
                            sOAPForm.PulseLeft = sOAPForm.PulseLeft + ", " + item;
                        }

                    }
                }


                sOAPForm.DateFilledIn = DateTime.Now;
                int groupingid = (int)TempData["MultiID"];
                TempData["MultiID"] = groupingid;
                sOAPForm.GroupingID = groupingid;

                db.SOAPFormDatabase.Add(sOAPForm);
                db.SaveChanges();
                //return RedirectToAction("GeneratePDFforSOAP");
                TempData["SOAPFormID"] = sOAPForm.ID;
                return RedirectToAction("GetDoctorSignatureSOAP", "Signatures");
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


        public ActionResult GeneratePDFforSOAP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //ID is soapform ID. id is subject id
            //int ID = (int)TempData["SOAPFormID"];
            //int ID = id;
            SOAPForm sOAPFORM = db.SOAPFormDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/PDFSoap.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/PDFSoap.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill header
            stamper.AcroFields.SetField("PractionerName1", sOAPFORM.PractionerName);
            stamper.AcroFields.SetField("LicenseNumber1", sOAPFORM.PractionerLicenseNumber);
            stamper.AcroFields.SetField("PractionerName2", sOAPFORM.PractionerName);
            stamper.AcroFields.SetField("LicenseNumber2", sOAPFORM.PractionerLicenseNumber);
            stamper.AcroFields.SetField("PractionerName3", sOAPFORM.PractionerName);
            stamper.AcroFields.SetField("LicenseNumber3", sOAPFORM.PractionerLicenseNumber);

            //fill fields on pdf form. 
            stamper.AcroFields.SetField("PatientName", sOAPFORM.PatientName);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());

            stamper.AcroFields.SetField("BP", sOAPFORM.BP);
            //stamper.AcroFields.SetField("BP", sOAPFORM.BP.ToString());

            stamper.AcroFields.SetField("PresentingProblems", sOAPFORM.PresentingProblems);
            stamper.AcroFields.SetField("Symptom", sOAPFORM.SymptomsGeneral);
            stamper.AcroFields.SetField("ChillsFeverNotes", sOAPFORM.SymptomsChillsFeverNotes);
            stamper.AcroFields.SetField("PerspirationNotes", sOAPFORM.SymptomsPerspiratonNotes);
            stamper.AcroFields.SetField("UrinationNotes", sOAPFORM.SymptomsUrinationNotes);
            stamper.AcroFields.SetField("HeadacheBodyNotes", sOAPFORM.SymptomsHeadacheBodyacheNotes);
            stamper.AcroFields.SetField("RespirationNotes", sOAPFORM.SymptomsRespirationNotes);
            stamper.AcroFields.SetField("SleepEnergyNotes", sOAPFORM.SymptomsSleepEnergyNotes);
            stamper.AcroFields.SetField("ReproductiveNotes", sOAPFORM.SymptomsReproductiveNotes);
            stamper.AcroFields.SetField("MentalEmotionalNotes", sOAPFORM.SymptomsMentalEmotionalNotes);
            stamper.AcroFields.SetField("EarsEyesTeethGumsNotes", sOAPFORM.SymptomsEarsEyesTeethGumsNotes);
            stamper.AcroFields.SetField("AppetiteDigestionDefecationNotes", sOAPFORM.SymptomsAppetiteDigestionDefecationNotes);
            stamper.AcroFields.SetField("PalpitationDizzinessNumbnessNotes", sOAPFORM.SymptomsPalpitationDizzinessNumbnessNotes);

            stamper.AcroFields.SetField("TreatmentPrinciples", sOAPFORM.TreatmentPrinciples); //missed this one
            stamper.AcroFields.SetField("TongueBodyShape", sOAPFORM.TongueBodyShape);
            stamper.AcroFields.SetField("ThirstNotes", sOAPFORM.ThirstNotes); //forgot to add
            stamper.AcroFields.SetField("OtherPhysicalExamsNotes", sOAPFORM.OtherPhysicalExamsNotes); //forgot to add
            stamper.AcroFields.SetField("AppointmentStartTime", sOAPFORM.TimeTreatmentStarts);
            stamper.AcroFields.SetField("AppointmentEndTime", sOAPFORM.TimeTreatmentEnds);

            //
            stamper.AcroFields.SetField("TongueBodyColor", sOAPFORM.TongueBodyColor);
            stamper.AcroFields.SetField("TongueCoating", sOAPFORM.TongueCoating);
            stamper.AcroFields.SetField("TongueColoration", sOAPFORM.CoatColoration);
            stamper.AcroFields.SetField("TongueRooting", sOAPFORM.CoatRooting);

            //needling sets
            stamper.AcroFields.SetField("NeedlingSet1", sOAPFORM.NeedlingSet1asString);
            stamper.AcroFields.SetField("NeedlingSet2", sOAPFORM.NeedlingSet2asString);
            stamper.AcroFields.SetField("NeedlingSet3", sOAPFORM.NeedlingSet3asString);
            stamper.AcroFields.SetField("NeedlingSet4", sOAPFORM.NeedlingSet4asString);
            stamper.AcroFields.SetField("NeedlingSet5", sOAPFORM.NeedlingSet5asString);
            stamper.AcroFields.SetField("NeedlingSet6", sOAPFORM.NeedlingSet6asString);

            stamper.AcroFields.SetField("SubjectiveObjectiveNotes", sOAPFORM.SubjectiveObjectiveNotes);
            stamper.AcroFields.SetField("PulseRight", sOAPFORM.PulseRight);
            stamper.AcroFields.SetField("PulseLeft", sOAPFORM.PulseLeft);
            stamper.AcroFields.SetField("AssessmentDiagnosis", sOAPFORM.AssessmentandDiagnosis);
       
            stamper.AcroFields.SetField("PlanofTreatment", sOAPFORM.PlanofTreatment);

            stamper.AcroFields.SetField("HerbalFormulaId1", sOAPFORM.HerbalFormulaId1);
            stamper.AcroFields.SetField("HerbalFormulaId1Directions", sOAPFORM.HerbalFormulaId1Directions);

            stamper.AcroFields.SetField("HerbalFormulaId2", sOAPFORM.HerbalFormulaId2);
            stamper.AcroFields.SetField("HerbalFormulaId2Directions", sOAPFORM.HerbalFormulaId2Directions);

            stamper.AcroFields.SetField("HerbalFormulaId3", sOAPFORM.HerbalFormulaId3);
            stamper.AcroFields.SetField("HerbalFormulaId3Directions", sOAPFORM.HerbalFormulaId3Directions);

            stamper.AcroFields.SetField("PostTreatmentAssessment", sOAPFORM.PostTreatmentAssessment);
            stamper.AcroFields.SetField("Recommendations", sOAPFORM.Recomendations);
            stamper.AcroFields.SetField("Date_2", DateTime.Now.ToShortDateString());


            //all checkboxes
            if (sOAPFORM.SymptomsChillsFeverNone == true)
            {
                stamper.AcroFields.SetField("ChillsFeverNone", "200", true);
            }
            if (sOAPFORM.SymptomsChillsFeverObjective == true)
            {
                stamper.AcroFields.SetField("ChillsFeverS", "201", true);
            }
            if (sOAPFORM.SymptomsChillsFeverSubjective == true)
            {
                stamper.AcroFields.SetField("ChillsFeverO", "202", true);
            }
            if (sOAPFORM.SymptomsHeadacheBodyacheNone == true)
            {
                stamper.AcroFields.SetField("HeadacheNone", "206", true);
            }
            if (sOAPFORM.SymptomsSleepEnergyNormal == true)
            {
                stamper.AcroFields.SetField("SleepNone", "207", true);
            }
            if (sOAPFORM.SymptomsSleepEnergySubjective == true)
            {
                stamper.AcroFields.SetField("SleepS", "208", true);
            }
            if (sOAPFORM.SymptomsSleepEnergyObjective == true)
            {
                stamper.AcroFields.SetField("SleepO", "209", true);
            }
            if (sOAPFORM.SymptomsMentalEmotionalNormal == true)
            {
                stamper.AcroFields.SetField("MentalNormal", "210", true);
            }
            if (sOAPFORM.SymptomsMentalEmotionalSubjective == true)
            {
                stamper.AcroFields.SetField("MentalS", "211", true);
            }
            if (sOAPFORM.SymptomsMentalEmotionalObjective == true)
            {
                stamper.AcroFields.SetField("MentalO", "212", true);
            }
            if (sOAPFORM.SymptomsAppetiteDigestionDefecationNormal == true)
            {
                stamper.AcroFields.SetField("AppetiteNormal", "213", true);
            }
            if (sOAPFORM.SymptomsAppetiteDigestionDefecationSubjective == true)
            {
                stamper.AcroFields.SetField("AppetiteS", "214", true);
            }
            if (sOAPFORM.SymptomsAppetiteDigestionDefecationObjective == true)
            {
                stamper.AcroFields.SetField("AppetiteO", "215", true);
            }
            if (sOAPFORM.SymptomsPerspiratonNone == true)
            {
                stamper.AcroFields.SetField("PerspirationNone", "216", true);
            }
            if (sOAPFORM.SymptomsPerspiratonSubjective == true)
            {
                stamper.AcroFields.SetField("PerspirationS", "217", true);
            }
            if (sOAPFORM.SymptomsPerspiratonObjective == true)
            {
                stamper.AcroFields.SetField("PerspirationO", "218", true);
            }
            if (sOAPFORM.SymptomsUrinationNormal == true)
            {
                stamper.AcroFields.SetField("UrinationNormal", "219", true);
            }
            if (sOAPFORM.SymptomsUrinationSubjective == true)
            {
                stamper.AcroFields.SetField("UrinationS", "220", true);
            }
            if (sOAPFORM.SymptomsUrinationObjective == true)
            {
                stamper.AcroFields.SetField("UrinationO", "221", true);
            }
            if (sOAPFORM.SymptomsRespirationNormal == true)
            {
                stamper.AcroFields.SetField("RespirationNormal", "222", true);
            }
            if (sOAPFORM.SymptomsRespirationSubjective == true)
            {
                stamper.AcroFields.SetField("RespirationS", "223", true);
            }
            if (sOAPFORM.SymptomsRespirationObjective == true)
            {
                stamper.AcroFields.SetField("RespirationO", "224", true);
            }
            if (sOAPFORM.SymptomsReproductiveNormal == true)
            {
                stamper.AcroFields.SetField("ReproductiveNormal", "225", true);
            }
            if (sOAPFORM.SymptomsEarsEyesTeethGumsNormal == true)
            {
                stamper.AcroFields.SetField("EarsNormal", "226", true);
            }
            if (sOAPFORM.SymptomsEarsEyesTeethGumsSubjective == true)
            {
                stamper.AcroFields.SetField("EarsS", "227", true);
            }
            if (sOAPFORM.SymptomsEarsEyesTeethGumsObjective == true)
            {
                stamper.AcroFields.SetField("EarsO", "228", true);
            }
            if (sOAPFORM.SymptomsPalpitationDizzinessNumbnessNone == true)
            {
                stamper.AcroFields.SetField("PalpitationNone", "229", true);
            }
            if (sOAPFORM.SymptomsPalpitationDizzinessNumbnessSubjective == true)
            {
                stamper.AcroFields.SetField("PalpitationS", "230", true);
            }
            if (sOAPFORM.SymptomsPalpitationDizzinessNumbnessObjective == true)
            {
                stamper.AcroFields.SetField("PalpitationO", "231", true);
            }

            if (sOAPFORM.NeedlingSet1ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation1", "232", true);
            }
            if (sOAPFORM.NeedlingSet2ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation2", "233", true);
            }
            if (sOAPFORM.NeedlingSet3ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation3", "234", true);
            }
            if (sOAPFORM.NeedlingSet4ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation4", "235", true);
            }
            if (sOAPFORM.NeedlingSet5ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation5", "236", true);
            }
            if (sOAPFORM.NeedlingSet6ElectricalStimulation == true)
            {
                stamper.AcroFields.SetField("ElectricalStimulation6", "237", true);
            }

            if (sOAPFORM.NeedlingSet1TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa1", "238", true);
            }
            if (sOAPFORM.NeedlingSet2TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa2", "239", true);
            }
            if (sOAPFORM.NeedlingSet3TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa3", "240", true);
            }
            if (sOAPFORM.NeedlingSet4TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa4", "241", true);
            }
            if (sOAPFORM.NeedlingSet5TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa5", "242", true);
            }
            if (sOAPFORM.NeedlingSet6TuiNa == true)
            {
                stamper.AcroFields.SetField("TuiNa6", "243", true);
            }

            if (sOAPFORM.NeedlingSet1CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy1", "244", true);
            }
            if (sOAPFORM.NeedlingSet2CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy2", "245", true);
            }
            if (sOAPFORM.NeedlingSet3CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy3", "246", true);
            }
            if (sOAPFORM.NeedlingSet4CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy4", "247", true);
            }
            if (sOAPFORM.NeedlingSet5CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy5", "248", true);
            }
            if (sOAPFORM.NeedlingSet6CuppingTherapy == true)
            {
                stamper.AcroFields.SetField("CuppingTherapy6", "249", true);
            }

            if (sOAPFORM.CleanNeedSet == true)
            {
                stamper.AcroFields.SetField("CleanNeedle", "250", true);
            }

            if (sOAPFORM.ThirstNormal == true)
            {
                stamper.AcroFields.SetField("ThirstNormal", "203", true);
            }
            if (sOAPFORM.ThirstSubjective == true)
            {
                stamper.AcroFields.SetField("ThirstS", "204", true);
            }
            if (sOAPFORM.ThirstObjective == true)
            {
                stamper.AcroFields.SetField("ThirstO", "205", true);
            }










            //put in signatures
            Signature signatureclient = (Signature)TempData["SignaturePractioner"];

            if (signatureclient == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //first signature
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(signatureclient.MySignature));
            System.Drawing.Image img = x;
            img.Save(Server.MapPath("~/Content/signatureclient.png"), System.Drawing.Imaging.ImageFormat.Png);
            iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/signatureclient.png"));
            // Scale image to fit
            sigImg.ScaleToFit(70, 70);
            // Set signature position on page
            sigImg.SetAbsolutePosition(55, 382);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(3);
            over.AddImage(sigImg);


            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            string path = "~/PDF_handler/PDFSoap.pdf";
            string tag = "SOAP";
            //string GroupingID = id.ToString();

            //pick up subject grouping id from tempdata
            int groupingid = (int)TempData["MultiID"];
            string GroupingID = groupingid.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }
    }
}
