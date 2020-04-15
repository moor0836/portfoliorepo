using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineTheSecond.Models.EF
{
    public class ItemVendResult
    {
        public bool success { get; set; }
        public string failureMessage { get; set; }
        public decimal change { get; set; }
    }
}