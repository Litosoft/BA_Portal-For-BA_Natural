using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;

namespace BA_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int thanks=0)
        {
            ViewBag.Thanks = thanks;
            return View();
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