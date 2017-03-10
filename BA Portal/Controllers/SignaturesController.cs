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
    public class SignaturesController : Controller
    {
        private SignatureDbContext db = new SignatureDbContext();

        // GET: Signatures
        public ActionResult Index()
        {
            return View(db.SignatureDatabase.ToList());
        }

        // GET: Signatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signature signature = db.SignatureDatabase.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // GET: Signatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                db.SignatureDatabase.Add(signature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signature);
        }

        // GET: Signatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signature signature = db.SignatureDatabase.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // POST: Signatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signature);
        }

        // GET: Signatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signature signature = db.SignatureDatabase.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // POST: Signatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Signature signature = db.SignatureDatabase.Find(id);
            db.SignatureDatabase.Remove(signature);
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

        public ActionResult GenerateSignedPDFforInsurance()
        {

            return View();
        }

        public ActionResult GeneratePDFforSignature(int? id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/


            Signature signature = db.SignatureDatabase.Find(id);

            //this can be handled by converting the signature to jpg and saving locally in contents.
            //then accessing it when itextsharp needs it. then delete the stored local file before ending the function. 
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(signature.MySignature));
            System.Drawing.Image img = x;
            img.Save(Server.MapPath("~/Content/test1.png"), System.Drawing.Imaging.ImageFormat.Png);

            //debugging
            //img.Save(Server.MapPath("~/Content/test1.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

            //create new pdf form from template
            var reader = new PdfReader(Server.MapPath("~/Content/PDFforPersonalInformation.pdf"));
            var output = new MemoryStream();
            var stamper = new PdfStamper(reader, output);

            iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/test1.png"));
            // Scale image to fit
            sigImg.ScaleToFit(80, 80);
            // Set signature position on page
            sigImg.SetAbsolutePosition(170, 55);  //x, y
            // Add signatures to desired page
            PdfContentByte over = stamper.GetOverContent(1);
            over.AddImage(sigImg);

            //close and create new pdf
            // Form fields should no longer be editable
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();

            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToShortDateString() + ".pdf");
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(output.ToArray());
            Response.End();

            //delete signature image
            FileInfo file = new FileInfo(Server.MapPath("~/Content/test1.png"));
            file.Delete();

            //return View();
            return RedirectToAction("Index");
        }


        //entry point for new insurance forms
        public ActionResult CaptureIDandRedirectforInsurance(int? id =1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TempData["InsuranceID"] = id;

            return RedirectToAction("GetClientSignatureInsurance");

        }



        public ActionResult GetClientSignatureInsurance()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetClientSignatureInsurance([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                TempData["SignatureClientInsurance"] = signature;
                int idInsurance = (int)TempData["InsuranceID"];

                return RedirectToAction("GeneratePDFforInsurance", "Subjects", new { id = idInsurance});
            }

            return View(signature);
        }

        public ActionResult GetClientSignaturePI()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetClientSignaturePI([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                TempData["SignatureClientPI"] = signature;

                return RedirectToAction("GetPractitionerSignaturePI");
            }

            return View(signature);
        }


        public ActionResult GetClientSignature()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetClientSignature([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                TempData["SignatureClient"] = signature;

                return RedirectToAction("GetPractitionerSignature");
            }

            return View(signature);
        }

        // ////////////////////////////////////////////////////////////////////////
        // seperator of similar functions
        // ////////////////////////////////////////////////////////////////////////

        public ActionResult GetPractitionerSignature()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPractitionerSignature([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                TempData["SignaturePractioner"] = signature;
                return RedirectToAction("FinalResults");
            }

            return View(signature);
        }



        public ActionResult GetPractitionerSignaturePI()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPractitionerSignaturePI([Bind(Include = "ID,MySignature")] Signature signature)
        {
            if (ModelState.IsValid)
            {
                TempData["SignaturePractioner"] = signature;

                int ID = (int)TempData["DatabaseID_PI"];

                return RedirectToAction("GeneratePDFforPI" + "/" + ID, "Subjects");
            }

            return View(signature);
        }




        public ActionResult FinalResults()
        {

            List<Signature> siglist = new List<Signature>();
            Signature signature = new Signature();
            signature = (Signature)TempData["SignatureClient"];
            siglist.Add(signature);

            signature = (Signature)TempData["SignaturePractioner"];
            siglist.Add(signature);



            return View(siglist);
        }

        public ActionResult Test()
        {

            return View();
        }


        }
}
