using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Portal.Models;

namespace BA_Portal.Controllers
{
    public class NewFunctionTestsController : Controller
    {
        // GET: NewFunctionTests
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            string date1 = date.ToString();
            string date2 = date.Date.ToString();
            string date3 = date.Year.ToString();
            string date4 = date.ToShortDateString();
            ViewBag.date1 = date1;
            ViewBag.date2 = date2;
            ViewBag.date3 = date3;
            ViewBag.date4 = date4;


            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        //the way this works, is in the argument set a value for the argument. this is the default
        //value of the argument. if no argument is recieved it will default to this.
        //however if an argument is recieved then it will be replaced.
        //this is how to create optional paramaters. which I will be using in
        //form personal information.
        public ActionResult OptionalParamater(string teststring = "blank")
        {
            ViewBag.teststring = teststring;

            return View();
        }

        public ActionResult PrintIndex()
        {

            return new ViewAsPdf("Index", new { name = "NewFunctionTests" });
            //return new ViewAsPdf("Index", new { name = "NewFunctionTests" }) { FileName = "Test.pdf" };
            //return new ActionAsPdf("Index", new { name = "NewFunctionTests" }) { FileName = "Test.pdf" };
        }

        public DateTime Date()
        {
            DateTime now = DateTime.Now;

            return (now);
        }

        public ActionResult TESTFORM()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult TESTFORM1(string string1, string string2, [Bind(Include = "ID,SearchTag,PDFinbytes")] PDF pDF)
        {
            pDF.Description = string2;
            
            TempData["pdftest"] = pDF;

            return RedirectToAction("CheckFormValues");
        }

        public ActionResult CheckFormValues()
        {
            PDF pDF = new PDF();
            pDF = (PDF)TempData["pdftest"];
            return View(pDF);

        }
    }
}