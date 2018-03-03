using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace BA_Portal.Models
{
    public class QuickSoapNote
    {
        // Quick Note 
        public int ID { get; set; }
        public string Name { get; set; }
        public int UniqueID { get; set; }
        public string ReturnDateRecommended { get; set; }
        public string HerbalSupplement { get; set; }
        public string OtherDetails { get; set; }

        // Quick Soap Note
    }

    public class QuickSoapNoteDbContext : System.Data.Entity.DbContext
    {
        public QuickSoapNoteDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<QuickSoapNote> QuickSoapNoteDatabase { get; set; }
    }
}
