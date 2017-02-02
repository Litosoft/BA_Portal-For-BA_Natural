using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BA_Portal.Models
{
    public class FormPersonalinfo
    {
        //database ID
        public int ID { get; set; }
        public int GroupingID { get; set; }
        public DateTime DateCreated { get; set; }

        //all conditions
        public bool Allergy { get; set; }
        public string AllergyDescription { get; set; }

        public bool HighBloodPressure { get; set; }
        public bool LowBloodPressure { get; set; }
        public bool HeartCondition { get; set; }
        public bool Diabetes { get; set; }
        public bool Anemia { get; set; }
        public bool HighCholesterol { get; set; }
        public bool Pacemaker { get; set; }
        public bool Epilepsy { get; set; }
        public bool Pregnant { get; set; }
        public bool Cancer { get; set; }
        public bool STD { get; set; }

        //reason for appointment

        public bool Pain { get; set; }
        public string PainDescription { get; set; }
        public bool Headache { get; set; }
        public string HeadacheDescription { get; set; }
        public bool CommonCold { get; set; }
        public bool HighBloodPressureConcern { get; set; }
        public bool Stress { get; set; }
        public bool Depression { get; set; }
        public bool Sleep { get; set; }
        public bool Menstruation { get; set; }
        public bool Fertility { get; set; }
        public bool WeightControl { get; set; }
        public bool Other { get; set; }



    }

    public class FormPersonalinfoDbContext : DbContext
    {
        public DbSet<FormPersonalinfo> FormPersonalinfoDatabase { get; set; }
    }
}