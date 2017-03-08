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
                return RedirectToAction("Index");
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

        public ActionResult SavePDFtoDatabase()
        {

            byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/PDF_handler/Elmo_Insurance_3_6_2017.pdf"));
            PDF testPDF = new PDF();
            testPDF.PDFinbytes = bytes;
            testPDF.SearchTag = "test";

            db.PDFDatabase.Add(testPDF);
            db.SaveChanges();
            return View();
            //return RedirectToAction("Index");

   
        }

        public ActionResult ReadPDFfromDatabase(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PDF pDF = db.PDFDatabase.Find(id);
            System.IO.File.WriteAllBytes(Server.MapPath("~/Content/testpdf.pdf"), pDF.PDFinbytes);

            return View();
        }



    }
}
