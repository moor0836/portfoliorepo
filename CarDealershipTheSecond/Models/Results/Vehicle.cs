using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models.Results
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ExColor { get; set; }
        public string InColor { get; set; }
        public string Style { get; set; }
        public string Transmission { get; set; }
        public int Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
    }
}