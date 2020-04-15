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
    [Authorize]
    public class SalesController : Controller
    {
        IRepository _repo = RepositoryFactory.Create();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Purchase(string VIN)
        {
            Vehicle model = _repo.GetVehicleByVIN(VIN);
            return View(model);
        }
    }
}