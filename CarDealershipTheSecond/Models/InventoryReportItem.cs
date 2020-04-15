using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models
{
    public class InventoryReportItem
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
    }
}