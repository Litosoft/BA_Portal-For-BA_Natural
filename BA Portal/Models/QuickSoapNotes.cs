using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace BA_Portal.Models
{
    public class QuickSoapNotes
    {
        // Quick Note 
        public int ID { get; set; }
        public string Name { get; set; }
        public int UniqueID { get; set; }
        public string ReturnDateRecommended { get; set; }
        public string HerbalSupplement { get; set; }
        public string OtherDetails { get; set; }

        // Quick Soap Note
        public string DateSeen { get; set; }
        public DateTime DateCompleted { get; set; }
        public string CPTcode { get; set; }
        public string NeedleSize { get; set; }
        public bool ElectroStimulation { get; set; }
        public string TreatmentTime { get; set; }
        public string PainScale { get; set; }
        public string NeedlesPerformed { get; set; }
        public string SField { get; set; }
        public string OField { get; set; }
        public string AField { get; set; }
        public string PField { get; set; }
        public string ICD10CM_Entry1 { get; set; }
        public string ICD10CM_Entry2 { get; set; }
        public string ICD10CM_Entry3 { get; set; }
        public string ICD10CM_Entry4 { get; set; }
        public string ICD10CM_Entry5 { get; set; }
    }

    public class QuickSoapNotesDbContext : System.Data.Entity.DbContext
    {
        public QuickSoapNotesDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<QuickSoapNotes> QuickSoapNotesDatabase { get; set; }
    }
}
