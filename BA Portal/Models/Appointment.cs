using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BA_Portal.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        public string PatientName { get; set; }
        public string ProcedureGiven { get; set; }
        public double PaymentCharged { get; set; }
        public bool PaidWithCredit { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string MerchandiseBought { get; set; }
        public string DoctorsNotes { get; set; }
        public int GroupingID { get; set; }

    }

    public class AppointmentDbContext : DbContext
    {

        public DbSet<Appointment> AppointmentsDatabase { get; set; }
    }

}