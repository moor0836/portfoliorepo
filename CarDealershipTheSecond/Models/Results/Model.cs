using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models.Results
{
    public class Model
    {
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public int StyleId { get; set; }
        public string ModelName { get; set; }
        public string Creator { get; set; }
        public DateTime DateAdded { get; set; }
        public Model()
        {
            DateAdded = DateTime.Today;
        }
    }
}