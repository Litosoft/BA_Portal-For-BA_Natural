using BA_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DAL, for allowing multiple queries in the same asp mvc page from different tables.
/// </summary>

namespace BA_Portal.BANaturalDAL
{
    public class BaNaturalDAL
    {
        public enum DBcontext_Options
        {
            SOAPFormDbContext,
            SignatureDbContext,
            SubjectDbContext,
            PDFDbContext,
            InsuranceVerificationDbContext,
            InsuranceInfoDbContext,
            QuickSoapNoteDbContext
        }

        // The general db context type for all functions.
        private System.Data.Entity.DbContext DbInUse;

        // The select DB context function
        public void SelectDBcontext(DBcontext_Options SelectedDB)
        {
            if(SelectedDB == DBcontext_Options.SOAPFormDbContext)
            {
                 DbInUse = new SOAPFormDbContext();
            }
            else if (SelectedDB == DBcontext_Options.SignatureDbContext)
            {
                 DbInUse = new SignatureDbContext();
            }
            else if (SelectedDB == DBcontext_Options.SubjectDbContext)
            {
                 DbInUse = new SubjectDbContext();
            }
            else if (SelectedDB == DBcontext_Options.PDFDbContext)
            {
                 DbInUse = new PDFDbContext();
            }
            else if (SelectedDB == DBcontext_Options.InsuranceVerificationDbContext)
            {
                 DbInUse = new InsuranceVerificationDbContext();
            }
            else if(SelectedDB == DBcontext_Options.InsuranceInfoDbContext)
            {
                 DbInUse = new InsuranceInfoDbContext();
            }
            else if(SelectedDB == DBcontext_Options.QuickSoapNoteDbContext)
            {
                 DbInUse = new QuickSoapNoteDbContext();
            }
        }

        /// All general database operations.
        // Select All

        // Select by parameter

        // Delete All

        // Delete by parameter

        // Insert new
    }
}
