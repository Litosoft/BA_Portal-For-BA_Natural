﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data;
using System.Data.Entity;
using System.Net;
using BA_Portal.Models;
using iTextSharp.text.pdf;
using System.IO;

namespace BA_Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*
        //exception handler. remove this to see detailed exceptions, but they will crash the application.
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            // Do something with the error.
            System.Diagnostics.Debug.WriteLine(exception);

            // Redirect somewhere or return an error code in case of web api
            Response.Redirect("/Account/Forbidden");
        }
        */
         



    }


}
