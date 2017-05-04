using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace BA_Portal.Models
{
    public class InsuranceInfo
    {
        public int ID { get; set; }
        public int GroupingID { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string PrimaryInsurer { get; set; }
        public string InsuranceHolder { get; set; }


        public string GroupNumber { get; set; }
        public string IDNumber { get; set; }
        public string PlanName { get; set; }

    }

    public class InsuranceInfoDbContext : System.Data.Entity.DbContext
    {
        public InsuranceInfoDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<InsuranceInfo> InsuranceInfoDatabase { get; set; }
    }
}