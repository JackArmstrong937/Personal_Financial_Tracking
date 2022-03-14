using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_Coding.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public string PayedTo { get; set; }
    }
}