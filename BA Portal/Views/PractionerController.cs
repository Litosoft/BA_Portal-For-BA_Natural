using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Portal.Models;

namespace BA_Portal.Views
{
    public class PractionerController : Controller
    {
        // GET: Practioner
        public ActionResult Index()
        {
            List<Practioner> PList = PractionerList.PractionerFilledList;
            
            return View(PList);
        }

        public ActionResult AddNewPractioner(string Name, string License)
        {
            Practioner practioner = new Practioner { Name = Name, LicenseID = License};
            PractionerList.PractionerFilledList.Add(practioner);

            return RedirectToAction("Index");
        }

        public ActionResult DeletePractioner(string NameDelete, string LicenseDelete)
        {
            Practioner practionerDelete = new Practioner { Name = NameDelete, LicenseID = LicenseDelete };
            PractionerList.PractionerFilledList.Remove(practionerDelete);



            return RedirectToAction("Index");
        }
    }
}