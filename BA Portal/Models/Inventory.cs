using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Portal.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        //all are on a continuous schedule of being cummulatively added to.
        //year and month simply reset at the start of every month/year
        public int SoldToDate { get; set; }
        public int SoldThisYear { get; set; }
        public int SoldThisMonth { get; set; }
        //updated start of the month and on the 15th (to untag previously updated)
        public bool PreviouslyUpdated { get; set; }
        //to make a graph of products sold. revenue can be calculated by this x price/unit
        public int[] SoldByMonthHistory { get; set; }
        //describe what a unit of this product is.
        public string DescriptonOfOneUnit { get; set; }
        public string PricePerUnit { get; set; }
    
        public string DescriptionOfProduct { get; set; }

    }
}