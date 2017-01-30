using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BA_Portal.Models
{
    public class Patient
    {
        //database ID
        public int ID { get; set; }

        //phyiscal attributes
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public bool GenderISfemale { get; set; }

        //address stuff
        public string Address { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneHome { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneCell { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //emergency contact
        public string EmergencyContact { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelationship { get; set; }

        public string ReferredBy { get; set; }
        public int PatiendID { get; set; }



    }

    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> PatientDatabase { get; set; }
    }

}