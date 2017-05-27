using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace BA_Portal.Models
{
    public class InsuranceVerification
    {

        public int ID { get; set; }
        public int GroupingID { get; set; }
        public bool OutOfNetworkCoverage { get; set; }
        public string NumberOfTreatment { get; set; }
        public string Limitations { get; set; }
        public string Deductibles { get; set; }
        public string DeductiblesMet { get; set; }
        public string CoInsurance { get; set; }
        public bool NoCoInsurance { get; set; }
        public string OutOfPocket { get; set; }
        public string OutOfPocketMet { get; set; }
        public string InsuranceCompany { get; set; }

    }

    public class InsuranceVerificationDbContext : System.Data.Entity.DbContext
    {
        public InsuranceVerificationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<InsuranceVerification> InsuranceVerificationDatabase { get; set; }
    }
}