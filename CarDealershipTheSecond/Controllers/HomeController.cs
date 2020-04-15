using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipTheSecond.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Specials()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}