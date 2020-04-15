using CarDealershipTheSecond.Data;
using CarDealershipTheSecond.Factory;
using CarDealershipTheSecond.Models;
using CarDealershipTheSecond.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipTheSecond.Controllers
{
    public class InventoryController : Controller
    {
        IRepository _repo = RepositoryFactory.Create();

        public ActionResult New()
        {
            return View();
        }
        public ActionResult Used()
        {
            return View();
        }
        public ActionResult Details(string VIN)
        {
            Vehicle model = _repo.GetVehicleByVIN(VIN);
            return View(model);
        }
    }
}