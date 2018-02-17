using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace BA_Portal.Models
{
    public class QuickNote
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UniqueID { get; set; }
        public string ReturnDateRecommended { get; set; }
        public string HerbalSupplement { get; set; }
        public string OtherDetails { get; set; }
    }

    public class QuickNoteDbContext : System.Data.Entity.DbContext
    {
        public QuickNoteDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<QuickNote> SignatureDatabase { get; set; }
    }
}
