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

namespace BA_Portal.Controllers
{
    public class SubjectsController : Controller
    {
        private SubjectDbContext db = new SubjectDbContext();

        // GET: Subjects
        public ActionResult Index(string searchString)
        {
            var ClientsSelected = from m in db.SubjectDatabase select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ClientsSelected = ClientsSelected.Where(s => s.Name.Contains(searchString));
            }



            return View(ClientsSelected);


            //return View(db.SubjectDatabase.ToList());
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
                subject.DateCreated = DateTime.Now;
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

        public ActionResult InsuranceForm()
        {
            return View();
        }

        public ActionResult Soap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            return View(subject);
        }

        public ActionResult PersonalInformation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            return View(subject);
        }

        public ActionResult Insurance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            return View(subject);
        }

        public ActionResult GeneratePDFforPI(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            

              //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/PDFforPersonalInformation.pdf"));
            var output = new MemoryStream();
            var stamper = new PdfStamper(reader, output);

           //fill fiels on pdf form. 
            stamper.AcroFields.SetField("Name", subject.Name);
            //string DOB = subject.DOB.Date.ToString();
            stamper.AcroFields.SetField("DOB", subject.DOB.Date.ToShortDateString());
            stamper.AcroFields.SetField("Address", subject.Address);
            stamper.AcroFields.SetField("Email", subject.Email);
            stamper.AcroFields.SetField("City", subject.City);
            stamper.AcroFields.SetField("Zip", subject.ZIP.ToString());
            stamper.AcroFields.SetField("Cell", subject.PhoneCell);
            stamper.AcroFields.SetField("HomePhone", subject.PhoneHome);
            stamper.AcroFields.SetField("EmergencyContact", subject.EmergencyContact);
            stamper.AcroFields.SetField("EmergencyPhone", subject.EmergencyContactPhone);
            stamper.AcroFields.SetField("Relationship", subject.EmergencyContactRelationship);
            stamper.AcroFields.SetField("ReferredBy", subject.ReferredBy);
            stamper.AcroFields.SetField("MonthNow", DateTime.Now.Month.ToString());
            stamper.AcroFields.SetField("DayNow", DateTime.Now.Day.ToString());
            stamper.AcroFields.SetField("YearNow", DateTime.Now.Year.ToString());

            //checkboxes
            if(subject.Allergy == true)
            {
            stamper.AcroFields.SetField("AllergyYes", "101", true);
            }
            if (subject.Allergy == false)
            {
            stamper.AcroFields.SetField("AllergyNo", "102", true);
            }
            if (subject.HighBloodPressure == true)
            {
            stamper.AcroFields.SetField("BloodPressure", "103", true);
            }
            if (subject.Diabetes == true)
            {
            stamper.AcroFields.SetField("Diabetes", "104", true);
            }
            if (subject.HighCholesterol == true)
            {
            stamper.AcroFields.SetField("HighCholesterol", "105", true);
            }
            if (subject.Epilepsy == true)
            {
            stamper.AcroFields.SetField("Epilepsy", "106", true);
            }
            if (subject.Cancer == true)
            {
            stamper.AcroFields.SetField("Cancer", "107", true);
            }
            if (subject.HeartCondition == true)
            {
            stamper.AcroFields.SetField("HeartCondition", "108", true);
            }
            if (subject.Anemia == true)
            {
            stamper.AcroFields.SetField("Anemia", "109", true);
            }
            if (subject.Pacemaker == true)
            {
            stamper.AcroFields.SetField("Pacemaker", "110", true);
            //stamper.AcroFields.SetField
            }
            if (subject.Pregnant == true)
            {
            stamper.AcroFields.SetField("Pregnant", "111", true);
            }
            if (subject.STD == true)
            {
            stamper.AcroFields.SetField("STD", "112", true);
            }
            stamper.AcroFields.SetField("Depression", "201", true);
            stamper.AcroFields.SetField("Sleep", "202", true);







            iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/backgroundimage1.jpg"));
            // Scale image to fit
            sigImg.ScaleToFit(60, 60);
            // Set signature position on page
            sigImg.SetAbsolutePosition(185, 60);
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
            over.AddImage(sigImg);







            //generate age
            DateTime now = DateTime.Today;
            int age = now.Year - subject.DOB.Year;
            if (now < subject.DOB.AddYears(age))
            {
                age--;
            }
            stamper.AcroFields.SetField("Age", age.ToString());

            //generate gender
            string gender = "Error";
            if(subject.Male == true)
            { gender = "Male"; }
            else if (subject.Female == true)
            { gender = "Female"; }
            stamper.AcroFields.SetField("Sex", gender);





            //close and create new pdf
            // Form fields should no longer be editable
            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            Response.AddHeader("Content-Disposition", "attachment; filename=" + subject.Name + "_Insurance" + "_" + DateTime.Now.ToShortDateString() + ".pdf");
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(output.ToArray());
            Response.End();


            //return View();
            return RedirectToAction("Index");
        }


    }
}
