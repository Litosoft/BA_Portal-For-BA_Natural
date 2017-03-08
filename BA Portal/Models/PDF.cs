using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace BA_Portal.Models
{
    public class PDF
    {
        public int ID { get; set; }
        //groupingid. who does this pdf belong to?
        public int GroupingID { get; set; }
        //tag insurance, personal information, soap
        public string SearchTag { get; set; }
        //same as searchtag, but possibly more descriptive.
        public string Description { get; set; }
        public byte[] PDFinbytes { get; set; }

    }

    public class PDFDbContext : DbContext
    {
        public DbSet<PDF> PDFDatabase { get; set; }
    }
}