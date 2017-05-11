using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Portal.Models
{
    public class Practioner
    {
        public string Name { get; set; }
        public string LicenseID { get; set; }

    }

    public static class PractionerList
    {
        public static List<Practioner> PractionerFilledList = new List<Practioner>() { new Practioner {Name = "Pei-Lu Chang", LicenseID = "AP3182" }, new Practioner { Name = "Chao Lung Liu", LicenseID = "AP2883" }  };
        

    }

   
}