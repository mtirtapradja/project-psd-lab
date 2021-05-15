using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Transaction
    {
        public DateTime Payment_Date { get; set; }
        public string Show_Name { get; set; }
        public DateTime Show_Time { get; set; }
        public int Quantity { get; set; }
        public int Total_Price { get; set; }
    }
}