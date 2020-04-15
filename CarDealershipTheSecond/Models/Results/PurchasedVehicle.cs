using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models.Results
{
    public class PurchasedVehicle
    {
        public string VIN { get; set; }
        public string CustomerName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal PurchasePrice { get; set; }
        public int FinanceTypeId { get; set; }
        public DateTime SaleDate { get; set; }
        public string Salesperson { get; set; }
        public PurchasedVehicle(string x)
        {
            VIN = x;
            SaleDate = DateTime.Today;
        }
        public PurchasedVehicle()
        {
            SaleDate = DateTime.Today;
        }
    }
}