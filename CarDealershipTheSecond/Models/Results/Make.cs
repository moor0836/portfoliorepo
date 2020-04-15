using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models.Results
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string Creator { get; set; }
        public DateTime DateAdded { get; set; }
        public Make()
        {
            DateAdded = DateTime.Today;
        }
    }
}