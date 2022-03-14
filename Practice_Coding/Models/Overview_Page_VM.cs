using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_Coding.Models
{
    public class Overview_Page_VM
    {
        public Categories Category_Totals { get; set; }
        public string New_Category_Name { get; set; }

        public DateTime NewDate { get; set; }
        public string NewPayTo { get; set; }
        public string NewDestription { get; set; }
        public string NewStatus { get; set; }
        public string TransactionType { get; set; }
        public List <Transaction>  New_Transactions { get; set; }
    }
}