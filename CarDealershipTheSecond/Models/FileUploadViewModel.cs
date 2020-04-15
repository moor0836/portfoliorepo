using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTheSecond.Models
{
    public class FileUploadViewModel
    {
        public string VIN { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}