using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;

namespace BA_Portal.Models
{
    public class Signature
    {
            public int ID { get; set; }
            [UIHint("SignaturePad")]
            public byte[] MySignature { get; set; }
        
    }

    public class SignatureDbContext : DbContext
    {
        public DbSet<Signature> SignatureDatabase { get; set; }
    }


}