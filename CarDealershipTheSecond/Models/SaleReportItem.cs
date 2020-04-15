using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models
{
    public class SaleReportItem
    {
        public string User { get; set; }
        public decimal TotalSales { get; set; }
        public int CountSales { get; set; }
    }
}