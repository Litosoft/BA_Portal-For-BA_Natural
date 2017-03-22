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
        public ActionResult Create(string Set1Point1, string Set1Point2, string Set1Point3, string Set1Point4, string Set1Point5, string Set2Point1, string Set2Point2, string Set2Point3, string Set2Point4, string Set2Point5, string Set3Point1, string Set3Point2, string Set3Point3, string Set3Point4, string Set3Point5, string Set4Point1, string Set4Point2, string Set4Point3, string Set4Point4, string Set4Point5, string Set5Point1, string Set5Point2, string Set5Point3, string Set5Point4, string Set5Point5, string Set6Point1, string Set6Point2, string Set6Point3, string Set6Point4, string Set6Point5, [Bind(Include = "ID,PractionerName,PractionerLicenseNumber,PatientName,BP,BodyTemperature,SubjectiveObjectiveNotes,DateFilledIn,TimeTreatmentStarted,TimeTreatmentEnded,SymptomsGeneral,PresentingProblems,SymptomsChillsFeverNotes,SymptomsChillsFeverNone,SymptomsChillsFeverSubjective,SymptomsChillsFeverObjective,SymptomsPerspiratonNotes,SymptomsPerspiratonNone,SymptomsPerspiratonSubjective,SymptomsPerspiratonObjective,SymptomsUrinationNotes,SymptomsUrinationNormal,SymptomsUrinationSubjective,SymptomsUrinationObjective,SymptomsHeadacheBodyacheNotes,SymptomsHeadacheBodyacheNone,SymptomsRespirationNotes,SymptomsRespirationNormal,SymptomsRespirationSubjective,SymptomsRespirationObjective,SymptomsSleepEnergyNotes,SymptomsSleepEnergyNormal,SymptomsSleepEnergySubjective,SymptomsSleepEnergyObjective,SymptomsReproductiveNotes,SymptomsReproductiveNormal,SymptomsMentalEmotionalNotes,SymptomsMentalEmotionalNormal,SymptomsMentalEmotionalSubjective,SymptomsMentalEmotionalObjective,SymptomsEarsEyesTeethGumsNotes,SymptomsEarsEyesTeethGumsNormal,SymptomsEarsEyesTeethGumsSubjective,SymptomsEarsEyesTeethGumsObjective,SymptomsAppetiteDigestionDefecationNotes,SymptomsAppetiteDigestionDefecationNormal,SymptomsAppetiteDigestionDefecationSubjective,SymptomsAppetiteDigestionDefecationObjective,SymptomsPalpitationDizzinessNumbnessNotes,SymptomsPalpitationDizzinessNumbnessNone,SymptomsPalpitationDizzinessNumbnessSubjective,SymptomsPalpitationDizzinessNumbnessObjective,TongueBodyColor,TongueCoating,CoatColoration,CoatRooting,PulseRight,PulseLeft,AssessmentandDiagnosis,PlanofTreatment,CleanNeedSet,NeedlingSet1ElectricalStimulation,NeedlingSet1TuiNa,NeedlingSet1CuppingTherapy,NeedlingSet2ElectricalStimulation,NeedlingSet2TuiNa,NeedlingSet2CuppingTherapy,NeedlingSet3ElectricalStimulation,NeedlingSet3TuiNa,NeedlingSet3CuppingTherapy,NeedlingSet4ElectricalStimulation,NeedlingSet4TuiNa,NeedlingSet4CuppingTherapy,NeedlingSet5ElectricalStimulation,NeedlingSet5TuiNa,NeedlingSet5CuppingTherapy,NeedlingSet6ElectricalStimulation,NeedlingSet6TuiNa,NeedlingSet6CuppingTherapy,HerbalFormulaId1,HerbalFormulaId1Directions,HerbalFormulaId2,HerbalFormulaId2Directions,HerbalFormulaId3,HerbalFormulaId3Directions,PostTreatmentAssessment,Recomendations")] SOAPForm sOAPForm)
        {
            if (ModelState.IsValid)
            {
                sOAPForm.NeedlingSet1 = new string[5];
                sOAPForm.NeedlingSet2 = new string[5];
                sOAPForm.NeedlingSet3 = new string[5];
                sOAPForm.NeedlingSet4 = new string[5];
                sOAPForm.NeedlingSet5 = new string[5];
                sOAPForm.NeedlingSet6 = new string[5];

                sOAPForm.NeedlingSet1[0] = Set1Point1;
                sOAPForm.NeedlingSet1[1] = Set1Point2;
                sOAPForm.NeedlingSet1[2] = Set1Point3;
                sOAPForm.NeedlingSet1[3] = Set1Point4;
                sOAPForm.NeedlingSet1[4] = Set1Point5;

                foreach (var item in sOAPForm.NeedlingSet1)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet1asString = sOAPForm.NeedlingSet1asString + item + ", ";
                    }

                }   

                sOAPForm.NeedlingSet2[0] = Set2Point1;
                sOAPForm.NeedlingSet2[1] = Set2Point2;
                sOAPForm.NeedlingSet2[2] = Set2Point3;
                sOAPForm.NeedlingSet2[3] = Set2Point4;
                sOAPForm.NeedlingSet2[4] = Set2Point5;

                foreach (var item in sOAPForm.NeedlingSet2)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet2asString = sOAPForm.NeedlingSet2asString + item + ", ";
                    }

                }

                sOAPForm.NeedlingSet3[0] = Set3Point1;
                sOAPForm.NeedlingSet3[1] = Set3Point2;
                sOAPForm.NeedlingSet3[2] = Set3Point3;
                sOAPForm.NeedlingSet3[3] = Set3Point4;
                sOAPForm.NeedlingSet3[4] = Set3Point5;

                foreach (var item in sOAPForm.NeedlingSet3)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet3asString = sOAPForm.NeedlingSet3asString + item + ", ";
                    }

                }

                sOAPForm.NeedlingSet4[0] = Set4Point1;
                sOAPForm.NeedlingSet4[1] = Set4Point2;
                sOAPForm.NeedlingSet4[2] = Set4Point3;
                sOAPForm.NeedlingSet4[3] = Set4Point4;
                sOAPForm.NeedlingSet4[4] = Set4Point5;

                foreach (var item in sOAPForm.NeedlingSet4)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet4asString = sOAPForm.NeedlingSet4asString + item + ", ";
                    }

                }

                sOAPForm.NeedlingSet5[0] = Set5Point1;
                sOAPForm.NeedlingSet5[1] = Set5Point2;
                sOAPForm.NeedlingSet5[2] = Set5Point3;
                sOAPForm.NeedlingSet5[3] = Set5Point4;
                sOAPForm.NeedlingSet5[4] = Set5Point5;

                foreach (var item in sOAPForm.NeedlingSet5)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet5asString = sOAPForm.NeedlingSet5asString + item + ", ";
                    }

                }

                sOAPForm.NeedlingSet6[0] = Set6Point1;
                sOAPForm.NeedlingSet6[1] = Set6Point2;
                sOAPForm.NeedlingSet6[2] = Set6Point3;
                sOAPForm.NeedlingSet6[3] = Set6Point4;
                sOAPForm.NeedlingSet6[4] = Set6Point5;

                foreach (var item in sOAPForm.NeedlingSet6)
                {
                    if (string.IsNullOrWhiteSpace(item) != true)
                    {
                        sOAPForm.NeedlingSet6asString = sOAPForm.NeedlingSet6asString + item + ", ";
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

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("PatientName", sOAPFORM.PatientName);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());
            stamper.AcroFields.SetField("BP", sOAPFORM.BP.ToString());

            stamper.AcroFields.SetField("PresentingProblems", sOAPFORM.PresentingProblems);
            stamper.AcroFields.SetField("Symptom", sOAPFORM.SymptomsGeneral);
            stamper.AcroFields.SetField("ChillFeverNotes", sOAPFORM.SymptomsChillsFeverNotes);
            stamper.AcroFields.SetField("PerspirationNotes", sOAPFORM.SymptomsPerspiratonNotes);
            //stamper.AcroFields.SetField("ThirstNotes", sOAPFORM.); //forgot to add
            stamper.AcroFields.SetField("UrinationNotes", sOAPFORM.SymptomsUrinationNotes);
            stamper.AcroFields.SetField("HeadacheBodyNotes", sOAPFORM.SymptomsHeadacheBodyacheNotes);
            stamper.AcroFields.SetField("RespirationNotes", sOAPFORM.SymptomsRespirationNotes);
            stamper.AcroFields.SetField("SleepEnergyNotes", sOAPFORM.SymptomsSleepEnergyNotes);
            stamper.AcroFields.SetField("ReproductiveNotes", sOAPFORM.SymptomsReproductiveNotes);
            stamper.AcroFields.SetField("MentalEmotionalNotes", sOAPFORM.SymptomsMentalEmotionalNotes);
            stamper.AcroFields.SetField("EarsEyesTeethGumsNotes", sOAPFORM.SymptomsEarsEyesTeethGumsNotes);
            stamper.AcroFields.SetField("AppetiteDigestionDefecationNotes", sOAPFORM.SymptomsAppetiteDigestionDefecationNotes);
            stamper.AcroFields.SetField("PalpitationDizzinessNumbnessNotes", sOAPFORM.SymptomsPalpitationDizzinessNumbnessNotes);

            //all checkboxes

            //
            stamper.AcroFields.SetField("TongueBodyColor", sOAPFORM.TongueBodyColor);
            //stamper.AcroFields.SetField("TongueBodyShape", sOAPFORM.);
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

            stamper.AcroFields.SetField("Notes1", sOAPFORM.SubjectiveObjectiveNotes);
            stamper.AcroFields.SetField("PulseRight", sOAPFORM.PulseRight.ToString());
            stamper.AcroFields.SetField("PulseLeft", sOAPFORM.PulseLeft.ToString());
            stamper.AcroFields.SetField("AssessmentDiagnosis", sOAPFORM.AssessmentandDiagnosis);
            //stamper.AcroFields.SetField("TreatmentPrinciples", sOAPFORM.tre; //missed this one
            stamper.AcroFields.SetField("PlanofTreatment", sOAPFORM.PlanofTreatment);


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
            sigImg.SetAbsolutePosition(55, 132);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
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
