using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Portal.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public bool GenderISfemale { get; set; }


        public string Address { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneCell { get; set; }
        public string Email { get; set; }

        public string EmergencyContact { get; set; }
        public string EmergencyContactPhone { get; set; }

        public string ReferredBy { get; set; }



    }
}