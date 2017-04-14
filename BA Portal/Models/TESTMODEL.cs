using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BA_Portal.Models
{
    public class TESTMODEL
    {
        public string string1 { get; set; }
        public string string2 { get; set; }
        public string string3 { get; set; }
        public string string4 { get; set; }
        public string[] stringarray { get;set;}
        public int testint { get; set; }

    }


    public class TestDbContext : DbContext
    {
        public DbSet<TESTMODEL> TestDatabase { get; set; }
    }
}