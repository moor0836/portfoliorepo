using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipTheSecond.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }
        
        public ActionResult Sales()
        {
            return View();
        }
    }
}