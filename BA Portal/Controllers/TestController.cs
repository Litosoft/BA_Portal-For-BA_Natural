﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Portal.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TESTFORM()
        {
            return View();
        }

        public ActionResult TESTFORM2()
        {
            return View();
        }
    }
}