using CarDealershipTheSecond.Data;
using CarDealershipTheSecond.Models;
using CarDealershipTheSecond.Models.Results;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Web.Caching;
using CarDealershipTheSecond.Factory;

namespace CarDealershipTheSecond.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        IRepository _repo = RepositoryFactory.Create();

        [NoCache]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddVehicle()
        {
            FileUploadViewModel model = new FileUploadViewModel();
            return View(model);
        }
        [NoCache]
        public ActionResult Edit(string VIN)
        {
            ViewBag.VIN = VIN;
            //Vehicle model = _repo.GetVehicleByVIN(VIN);
            FileUploadViewModel model = new FileUploadViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(FileUploadViewModel model)
        {
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Images/Vehicles"),
                    (model.VIN + ".jpg"));

                model.UploadedFile.SaveAs(path);

            };
            return RedirectToAction("Edit", new { VIN = model.VIN });
        }
        [HttpPost]
        public ActionResult EditVehicle(FileUploadViewModel model)
        {
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Images/Vehicles"),
                    (model.VIN + ".jpg"));

                model.UploadedFile.SaveAs(path);

            };
            return RedirectToAction("Index");
        }

        public ActionResult Makes()
        {
            return View();
        }

        public ActionResult Models()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return RedirectToAction("Register", "Account");
        }


        public class NoCache : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();

                base.OnResultExecuting(filterContext);
            }
        }
        
    }
}