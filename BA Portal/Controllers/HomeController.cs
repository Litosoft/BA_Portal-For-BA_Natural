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
using System.Web.Security;

namespace BA_Portal.Controllers
{
    public class HomeController : Controller
    {
        // DAL
        private QuickSoapNotesDbContext db2 = new QuickSoapNotesDbContext();

        // GET: Subjects
        public ActionResult Index(int thanks = 0, string searchString = "")
        {


            if (User.IsInRole("Guest"))
            {
                ViewBag.Thanks = thanks;
                return View();
            }

            // Select nothing by default
            var QuickNotesToday = from m in db2.QuickSoapNotesDatabase
                                  where m.UniqueID == -1
                                  select m;

            if(searchString == "+")
            {
                DateTime yesterday = DateTime.Today.AddDays(-1);
                ViewBag.Notes = 1;
                QuickNotesToday = from m in db2.QuickSoapNotesDatabase
                                    where m.DateCompleted > yesterday
                                    orderby m.DateCompleted descending
                                    select m;             
            }

            return View(QuickNotesToday);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult SessionCheck()
        {
            return View();
        }

        [HttpPost]
        public JsonResult KeepSessionAlive()
        {
            return new JsonResult { Data = "Success" };
        }

        [HttpPost]
        public JsonResult KeepAlive()
        {
            return new JsonResult { Data = "Success" };
        }

    }
}