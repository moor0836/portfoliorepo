using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models
{
    public class EasyEditVehicle
    {
        public string VIN { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int ExColorId { get; set; }
        public int InColorId { get; set; }
        public string Transmission { get; set; }
        public int Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
    }
}