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
    public class SubjectsController : Controller
    {
        private SubjectDbContext db = new SubjectDbContext();

        // GET: Subjects
        public ActionResult Index(string searchString = "This Default Search String is for Hippa Purposes")
        {
            var ClientsSelected = from m in db.SubjectDatabase
                                  orderby m.LastName, m.Name   
                                  select m;

        

                if (!String.IsNullOrEmpty(searchString))
            {
                ClientsSelected = from m in db.SubjectDatabase
                                  where m.Name == searchString || m.LastName == searchString || (m.Name + " " + m.LastName).Contains(searchString) || (m.PhoneCell).Contains(searchString)
                                  orderby m.LastName, m.Name                                 
                                  select m;
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
        public ActionResult Create([Bind(Include = "ID,Name,MiddleName,LastName,DOB,Male,Female,Address,City,ZIP,PhoneHome,PhoneCell,Email,EmergencyContact,EmergencyContactPhone,EmergencyContactRelationship,ReferredBy,DateCreated,Allergy,AllergyDescription,HighBloodPressure,LowBloodPressure,HeartCondition,Diabetes,Anemia,HighCholesterol,Pacemaker,Epilepsy,Pregnant,Cancer,STD,Pain,PainDescription,Headache,HeadacheDescription,CommonCold,HighBloodPressureConcern,Stress,Depression,Sleep,Menstruation,Fertility,WeightControl,Other")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.DateCreated = DateTime.Now;
                subject.LastSeen = DateTime.Now;

                //all caps for string fields in the personal information form.
                if (subject.Name != null)
                {
                    subject.Name = subject.Name.ToUpper();
                }
                if (subject.MiddleName != null)
                {
                    subject.MiddleName = subject.MiddleName.ToUpper();
                }
                if (subject.LastName != null)
                {
                    subject.LastName = subject.LastName.ToUpper();
                }
                if (subject.Address != null)
                {
                    subject.Address = subject.Address.ToUpper();
                }
                if (subject.City != null)
                {
                    subject.City = subject.City.ToUpper();
                }
                if (subject.EmergencyContact != null)
                {
                    subject.EmergencyContact = subject.EmergencyContact.ToUpper();
                }
                if (subject.EmergencyContactRelationship != null)
                {
                    subject.EmergencyContactRelationship = subject.EmergencyContactRelationship.ToUpper();
                }
                if (subject.ReferredBy != null)
                {
                    subject.ReferredBy = subject.ReferredBy.ToUpper();
                }
                if (subject.AllergyDescription != null)
                {
                    subject.AllergyDescription = subject.AllergyDescription.ToUpper();
                }
                if (subject.PainDescription != null)
                {
                    subject.PainDescription = subject.PainDescription.ToUpper();
                }
                if (subject.HeadacheDescription != null)
                {
                    subject.HeadacheDescription = subject.HeadacheDescription.ToUpper();
                }




                db.SubjectDatabase.Add(subject);
                db.SaveChanges();





                int ID = subject.ID;
                TempData["DatabaseID_PI"] = ID;

                return RedirectToAction("GetClientSignaturePI", "Signatures");
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
        public ActionResult Edit([Bind(Include = "ID,DateCreated,LastSeen,Name,MiddleName,LastName,DOB,Male,Female,Address,City,ZIP,PhoneHome,PhoneCell,Email,EmergencyContact,EmergencyContactPhone,EmergencyContactRelationship,ReferredBy,DateCreated,Allergy,AllergyDescription,HighBloodPressure,LowBloodPressure,HeartCondition,Diabetes,Anemia,HighCholesterol,Pacemaker,Epilepsy,Pregnant,Cancer,STD,Pain,PainDescription,Headache,HeadacheDescription,CommonCold,HighBloodPressureConcern,Stress,Depression,Sleep,Menstruation,Fertility,WeightControl,Other")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;

                //subject.DateCreated = DateTime.Now;
                //subject.LastSeen = DateTime.Now;

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

        public ActionResult GeneratePDF(int? id)
        {
            //personal info pdf generator

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            
            /*
             * This is how to save the file locally. using filestream, filemod.create, and a path that includes 
             * the filename 
             */

              //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/PDFforPersonalInformation.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/Content/GeneratePDFforPI.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 

            //combine all names for name string
            string combinedname = subject.Name + " " + subject.MiddleName + " " + subject.LastName;
            stamper.AcroFields.SetField("Name", combinedname);



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
            //paindescription
            stamper.AcroFields.SetField("PainDescription1", subject.PainDescription);
            //headache description
            stamper.AcroFields.SetField("HeadacheLocation", subject.HeadacheDescription);

            //checkboxes
            if (subject.Allergy == true)
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

            //box option 2
            if (subject.Depression == true)
            {
                stamper.AcroFields.SetField("Depression", "201", true);
            }
            if (subject.Sleep == true)
            {
            stamper.AcroFields.SetField("Sleep", "202", true);
            }
            if (subject.Menstruation == true)
            {
                stamper.AcroFields.SetField("Menstruation", "203", true);
            }
            if (subject.Fertility == true)
            {
                stamper.AcroFields.SetField("Fertility", "204", true);
            }
            if (subject.WeightControl == true)
            {
                stamper.AcroFields.SetField("WeightControl", "205", true);
            }
            if (subject.Other == true)
            {
                stamper.AcroFields.SetField("Other", "206", true);
            }
            if (subject.Pain == true)
            {
                stamper.AcroFields.SetField("Pain", "207", true);
            }


            if (subject.Headache == true)
            {
                stamper.AcroFields.SetField("Headache", "209", true);
            }


            if (subject.CommonCold == true)
            {
                stamper.AcroFields.SetField("CommonCold", "210", true);
            }
            if (subject.HighBloodPressure == true)
            {
                stamper.AcroFields.SetField("HighBloodPressure", "211", true);
            }
            if (subject.Stress == true)
            {
                stamper.AcroFields.SetField("Stress", "212", true);
            }


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
            if (subject.Male == true)
            { gender = "Male"; }
            else if (subject.Female == true)
            { gender = "Female"; }
            stamper.AcroFields.SetField("Sex", gender);



            //close and create new pdf
            // Form fields should no longer be editable
            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();
            /*
            Response.AddHeader("Content-Disposition", "attachment; filename=" + subject.Name + "_Insurance" + "_" + DateTime.Now.ToShortDateString() + ".pdf");
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(output.ToArray());
            Response.End();
            */
            
            //return View();
            return RedirectToAction("Index");
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
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/GeneratePDFforPI.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("Name", subject.Name + " " + subject.LastName);
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
            //paindescription
            stamper.AcroFields.SetField("PainDescription1", subject.PainDescription);
            //headache description
            stamper.AcroFields.SetField("HeadacheLocation", subject.HeadacheDescription);
            stamper.AcroFields.SetField("AllergyDescription", subject.AllergyDescription);



            //checkboxes
            if (subject.Allergy == true)
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

            //box option 2
            if (subject.Depression == true)
            {
                stamper.AcroFields.SetField("Depression", "201", true);
            }
            if (subject.Sleep == true)
            {
                stamper.AcroFields.SetField("Sleep", "202", true);
            }
            if (subject.Menstruation == true)
            {
                stamper.AcroFields.SetField("Menstruation", "203", true);
            }
            if (subject.Fertility == true)
            {
                stamper.AcroFields.SetField("Fertility", "204", true);
            }
            if (subject.WeightControl == true)
            {
                stamper.AcroFields.SetField("WeightControl", "205", true);
            }
            if (subject.Other == true)
            {
                stamper.AcroFields.SetField("Other", "206", true);
            }
            if (subject.Pain == true)
            {
                stamper.AcroFields.SetField("Pain", "207", true);
            }
            //stamper.AcroFields.SetField("Headache", "208", true);
            if (subject.Headache == true)
            {
                stamper.AcroFields.SetField("Headache", "209", true);
            }
            if (subject.CommonCold == true)
            {
                stamper.AcroFields.SetField("CommonCold", "210", true);
            }
            if (subject.HighBloodPressure == true)
            {
                stamper.AcroFields.SetField("HighBloodPressure", "211", true);
            }
            if (subject.Stress == true)
            {
                stamper.AcroFields.SetField("Stress", "212", true);
            }


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
            if (subject.Male == true)
            { gender = "Male"; }
            else if (subject.Female == true)
            { gender = "Female"; }
            stamper.AcroFields.SetField("Sex", gender);


            //put in signatures
            string SignatureOnFile = (string)TempData["SignatureOnFile"];
            Signature signatureclient = (Signature)TempData["SignatureClientPI"];
            Signature signaturepractioner = (Signature)TempData["SignaturePractioner"];

            if (signatureclient == null || signaturepractioner == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Image x;
            System.Drawing.Image img;
            iTextSharp.text.Image sigImg;
            PdfContentByte over;
            //first signature : Use "On File" if On File is true.

            if (signatureclient.MySignature != null)
            {
                x = (Bitmap)((new ImageConverter()).ConvertFrom(signatureclient.MySignature));
                img = x;
                img.Save(Server.MapPath("~/Content/signatureclient.png"), System.Drawing.Imaging.ImageFormat.Png);
            
                //if Signature on file was checked, use the signature on file default image.
                if (SignatureOnFile == "True")
                {
                    sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/SignatureOnFile.png"));
                }
                else
                {
                    sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/signatureclient.png"));
                }


                // Scale image to fit
                sigImg.ScaleToFit(80, 80);
                // Set signature position on page
                sigImg.SetAbsolutePosition(169, 50);  //x, y
                // Add signatures to desired page
                over = stamper.GetOverContent(1);
                over.AddImage(sigImg);
            }
            if (signatureclient.MySignature == null)
            {

                //if Signature on file was checked, use the signature on file default image.
                if (SignatureOnFile == "True")
                {
                    sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/SignatureOnFile.png"));

                    // Scale image to fit
                    sigImg.ScaleToFit(80, 80);
                    // Set signature position on page
                    sigImg.SetAbsolutePosition(169, 50);  //x, y
                    // Add signatures to desired page
                    over = stamper.GetOverContent(1);
                    over.AddImage(sigImg);
                }


            }


            if (signaturepractioner.MySignature != null)
            {
                    //second signature
                    x = (Bitmap)((new ImageConverter()).ConvertFrom(signaturepractioner.MySignature));
                img = x;
                img.Save(Server.MapPath("~/Content/signaturepractioner.png"), System.Drawing.Imaging.ImageFormat.Png);
                sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/signaturepractioner.png"));
                sigImg.ScaleToFit(80, 80);
                sigImg.SetAbsolutePosition(440, 50);
                over = stamper.GetOverContent(1);
                over.AddImage(sigImg);

            }


            

            //close and create new pdf
            // Form fields should no longer be editable
            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            /*
            Response.AddHeader("Content-Disposition", "attachment; filename=" + subject.Name + "_Insurance" + "_" + DateTime.Now.ToShortDateString() + ".pdf");
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(output.ToArray());
            Response.End();
            */

            string path = "~/PDF_handler/GeneratePDFforPI.pdf";
            string tag = "Personal Information";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }


        public ActionResult GeneratePDFforInsurance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/PDFforInsurance.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/GeneratePDFforInsurance.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("FullName", subject.Name + " " + subject.LastName);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());



            //put in signatures
            string SignatureOnFile = (string)TempData["SignatureOnFile"];
            Signature signatureclient = (Signature)TempData["SignatureClientInsurance"];

            if (signatureclient == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (signatureclient.MySignature != null)
            {
                if (SignatureOnFile == "True")
                {
                    //first signature
                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(signatureclient.MySignature));
                    System.Drawing.Image img = x;
                    PdfContentByte over = stamper.GetOverContent(1);

                    img.Save(Server.MapPath("~/Content/signatureclient.png"), System.Drawing.Imaging.ImageFormat.Png);
                    iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/SignatureOnFile.png"));
                    // Scale image to fit
                    sigImg.ScaleToFit(75, 75);
                    // Set signature position on page
                    sigImg.SetAbsolutePosition(110, 112);  //x, y
                                                           // Add signatures to desired page

                    over.AddImage(sigImg);


                    stamper.FormFlattening = true;

                    stamper.Close();
                    reader.Close();
                }
                else
                {
                //first signature
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(signatureclient.MySignature));
                System.Drawing.Image img = x;
                PdfContentByte over = stamper.GetOverContent(1);

                img.Save(Server.MapPath("~/Content/signatureclient.png"), System.Drawing.Imaging.ImageFormat.Png);
                iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/signatureclient.png"));
                // Scale image to fit
                sigImg.ScaleToFit(75, 75);
                // Set signature position on page
                sigImg.SetAbsolutePosition(110, 112);  //x, y
                                                       // Add signatures to desired page

                over.AddImage(sigImg);


                stamper.FormFlattening = true;

                stamper.Close();
                reader.Close();
                }

            }
            if (signatureclient.MySignature == null)
            {
                //if Signature on file was checked, use the signature on file default image.
                if (SignatureOnFile == "True")
                {
                    iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/SignatureOnFile.png"));
                    // Scale image to fit
                    sigImg.ScaleToFit(75, 75);
                    // Set signature position on page
                    sigImg.SetAbsolutePosition(110, 112);  //x, y
                                                           // Add signatures to desired page
                    PdfContentByte over = stamper.GetOverContent(1);
                    over.AddImage(sigImg);


                    stamper.FormFlattening = true;

                    stamper.Close();
                    reader.Close();
                }
            }



            string path = "~/PDF_handler/GeneratePDFforInsurance.pdf";
            string tag = "Insurance";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }

        public ActionResult GeneratePDFforDisclaimer1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/Disclaimer.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/Disclaimer.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("PrintName", subject.Name + " " + subject.LastName);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());



            //put in signatures
            Signature signatureclient = (Signature)TempData["SignatureClientInsurance"];

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

            string path = "~/PDF_handler/Disclaimer.pdf";
            string tag = "Disclaimer1";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }

        public ActionResult GeneratePDFforDisclaimer2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/Disclaimer_PT_Benefits.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/Disclaimer_PT_Benefits.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            
            //check which checkbox to tick.
            string MassagePaymentOption = (string)TempData["MassagePaymentOption"];

            if (MassagePaymentOption == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //fill fields on pdf form. 
            stamper.AcroFields.SetField("PrintName", subject.Name + " " + subject.LastName);
            stamper.AcroFields.SetField("DateFinal", DateTime.Now.ToShortDateString());

            if(MassagePaymentOption == "insurance")
            {
                //get initials
                string initials = subject.Name + " " + subject.LastName;
                var firstChars = " ";
                initials.Split(' ').ToList().ForEach(i => firstChars = firstChars + i[0]);

                stamper.AcroFields.SetField("DateInsurance", DateTime.Now.ToShortDateString());
                stamper.AcroFields.SetField("InitialInsurance", firstChars);

            }


            if (MassagePaymentOption == "outofpocket")
            {
                //get initials
                string initials = subject.Name + " " + subject.LastName;
                var firstChars = " ";
                initials.Split(' ').ToList().ForEach(i => firstChars = firstChars + i[0]);

                stamper.AcroFields.SetField("DatePocket", DateTime.Now.ToShortDateString());
                stamper.AcroFields.SetField("InitialPocket", firstChars);
            }
     


            //have to choose to fill in one field or the other. additional input required.

            //put in signatures
            Signature signatureclient = (Signature)TempData["SignatureClientInsurance"];

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
            sigImg.ScaleToFit(57, 57);
            // Set signature position on page
            sigImg.SetAbsolutePosition(45, 99);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
            over.AddImage(sigImg);


            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            string path = "~/PDF_handler/Disclaimer_PT_Benefits.pdf";
            string tag = "Disclaimer2";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }

        public ActionResult GeneratePDFforFinancialPolicy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/FinancialPolicy.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/FinancialPolicy.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("PrintName", subject.Name);
            stamper.AcroFields.SetField("PrintName2", subject.Name);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());



            //put in signatures
            Signature signatureclient = (Signature)TempData["SignatureClientInsurance"];

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
            sigImg.ScaleToFit(45, 45);
            // Set signature position on page
            sigImg.SetAbsolutePosition(100, 55);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
            over.AddImage(sigImg);


            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            string path = "~/PDF_handler/FinancialPolicy.pdf";
            string tag = "Financial_Policy";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }

        public ActionResult GeneratePDFforPayingatTimeofService(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);


            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/Paying.pdf"));
            //var output = new MemoryStream();
            var output = new FileStream(Server.MapPath("~/PDF_handler/Paying.pdf"), FileMode.Create);
            var stamper = new PdfStamper(reader, output);

            //fill fiels on pdf form. 
            stamper.AcroFields.SetField("PrintName", subject.Name);
            stamper.AcroFields.SetField("Date", DateTime.Now.ToShortDateString());



            //put in signatures
            Signature signatureclient = (Signature)TempData["SignatureClientInsurance"];

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
            sigImg.SetAbsolutePosition(80, 215);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
            over.AddImage(sigImg);


            stamper.FormFlattening = true;

            stamper.Close();
            reader.Close();

            string path = "~/PDF_handler/Paying.pdf";
            string tag = "PayingatTimeofService";
            string GroupingID = id.ToString();

            //return View();
            return RedirectToAction("SavePDFtoDatabase", "PDFs", new { path = path, tag = tag, GroupingID = GroupingID });
        }


        public ActionResult PassSubjecttoAllForms(int? id)
        {
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.SubjectDatabase.Find(id);
            TempData["PassSubjecttoAllForms"] = subject;


            return RedirectToAction("AllForms", "PDFs", new { GroupingID = id });
        }

        public ActionResult UpdateActivityStatus(int id)
        {

            Subject subject = db.SubjectDatabase.Find(id);
            subject.LastSeen = DateTime.Now;
 
            db.Entry(subject).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("PassSubjecttoAllForms", "Subjects", new { id = id });
        }

        public ActionResult PullSubjectForSOAP(int GroupingID)
        {

            Subject subject = db.SubjectDatabase.Find(GroupingID);

            //pass the object to soap using tempdata
            TempData["SOAP_Subject"] = subject;


            return RedirectToAction("Create", "SOAPForms", new { GroupingID = GroupingID });
        }



    }
}
