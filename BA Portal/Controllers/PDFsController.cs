using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BA_Portal.Models;
using System.IO;

namespace BA_Portal.Controllers
{
    public class PDFsController : Controller
    {
        private PDFDbContext db = new PDFDbContext();

        // GET: PDFs
        public ActionResult Index()
        {
            return View(db.PDFDatabase.ToList());
        }

        // GET: PDFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFDatabase.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // GET: PDFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SearchTag,PDFinbytes")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.PDFDatabase.Add(pDF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDF);
        }

        // GET: PDFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFDatabase.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SearchTag,PDFinbytes")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Subjects");
            }
            return View(pDF);
        }

        // GET: PDFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFDatabase.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDF pDF = db.PDFDatabase.Find(id);
            db.PDFDatabase.Remove(pDF);
            db.SaveChanges();
            return RedirectToAction("Index", "Subjects");
            //return RedirectToAction("PassSubjecttoAllForms", "Subjects", new { id = ID });
        }

        public ActionResult DeleteAllForms(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFDatabase.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SavePDFtoDatabase(string path, string tag, int GroupingID)
        {

            byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath(path));
            PDF PDFtoStore = new PDF();
            PDFtoStore.PDFinbytes = bytes;
            PDFtoStore.SearchTag = tag;
            PDFtoStore.GroupingID = GroupingID;
            PDFtoStore.Description = DateTime.Now.ToShortDateString();
            //PDFtoStore.Description = DateTime.Now.ToString();

            db.PDFDatabase.Add(PDFtoStore);
            db.SaveChanges();


            if(PDFtoStore.SearchTag == "Personal Information")
            {

                return RedirectToAction("TakeAnotherAction", "PDFs", new { GroupingID = GroupingID });
            }

            if (PDFtoStore.SearchTag == "SOAP")
            {
                //if soap pass to one more field before all forms and set last seen to now.

                return RedirectToAction("UpdateActivityStatus", "Subjects", new { id = GroupingID });
                //return RedirectToAction("PassSubjecttoAllForms", "Subjects", new { id = GroupingID });
            }

            return RedirectToAction("PassSubjecttoAllForms", "Subjects", new { id = GroupingID });

   
        }


        public FileContentResult ReadPDFfromDatabase(int? id)
        {

            PDF pDF = db.PDFDatabase.Find(id);
            System.IO.File.WriteAllBytes(Server.MapPath("~/PDF_handler/readpdf.pdf"), pDF.PDFinbytes);
            byte[] doc = pDF.PDFinbytes;
            Response.AppendHeader("Content-Disposition", "inline; filename=" + "readpdf.pdf");
            return File(doc, "application/pdf");

        }


        public ActionResult RedirectToPatientSOAPIndex(int id)
        {
            int passid = id;
            return RedirectToAction("PatientSOAPIndex", "SOAPForms", new { id = passid });

        }

        public ActionResult RedirectToPatientInsuranceIndex(int id)
        {
            int passid = id;
            return RedirectToAction("PatientInsuranceIndex", "InsuranceInfoes", new { id = passid });

        }

        public ActionResult RedirectToPatientInsuranceVerificationIndex(int id)
        {
            int passid = id;
            return RedirectToAction("PatientInsuranceIndex", "InsuranceVerifications", new { id = passid });

        }

        public ActionResult TakeAnotherAction(int? GroupingID)
        {
            
            if (GroupingID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ID = GroupingID;

         

            return View();
        }

        public ActionResult AllForms(int? GroupingID)
        {
            if (GroupingID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subject = (Subject)TempData["PassSubjecttoAllForms"];

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ID = GroupingID;

            ViewBag.Name = subject.Name;
            ViewBag.DOB = subject.DOB.ToShortDateString();
            ViewBag.PhoneHome = subject.PhoneHome;
            ViewBag.PhoneCell = subject.PhoneCell;
            ViewBag.Id = subject.ID;

            ViewBag.City = subject.City;
            ViewBag.Email = subject.Email;
            ViewBag.Allergy = subject.Allergy.ToString();
            ViewBag.ReferredBy = subject.ReferredBy;

            ViewBag.firstseen = subject.DateCreated.ToShortDateString();
            ViewBag.lastseen = subject.LastSeen.ToShortDateString();


            var FormsSelected = from m in db.PDFDatabase select m;
            //FormsSelected = FormsSelected.Where(s => s.GroupingID.Equals(GroupingID));
            FormsSelected = FormsSelected.Where(s => s.GroupingID == GroupingID);

            return View(FormsSelected);


        }


        public ActionResult file(int id, string RedirectIdentifier)
        {

            TempData["GroupingID"] = id;
            TempData["tag"] = RedirectIdentifier;
            //int id, string RedirectIdentifier 


            return View();
        }
        [HttpPost]
        public ActionResult file(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/PDF_handler/Scans"), Path.GetFileName("Scans.pdf"));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    int id = (int)TempData["GroupingID"];
                    string tagstring = (string)TempData["tag"];
                    string pathforfile = "~/PDF_handler/Scans/Scans.pdf";

                    return RedirectToAction("SavePDFtoDatabase", "PDFs", new { GroupingID = id, path = pathforfile, tag = tagstring});


                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }


    }
}
