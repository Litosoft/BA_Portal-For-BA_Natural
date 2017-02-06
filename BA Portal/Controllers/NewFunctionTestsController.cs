using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Portal.Controllers
{
    public class NewFunctionTestsController : Controller
    {
        // GET: NewFunctionTests
        public ActionResult Index()
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

        public DateTime Date()
        {
            DateTime now = DateTime.Now;

            return (now);
        }
    }
}