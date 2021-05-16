using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class ShowDetail
    {
        public string Show_Name { get; set; }
        public string Seller_Name { get; set; }
        public int Show_Price { get; set; }
        public string Description { get; set; }
        public int Average_Rating { get; set; }
    }
}