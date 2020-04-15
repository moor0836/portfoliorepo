using CarDealershipTheSecond.Data;
using CarDealershipTheSecond.Factory;
using CarDealershipTheSecond.Models;
using CarDealershipTheSecond.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealershipTheSecond.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        IRepository _repo = RepositoryFactory.Create();

        [Route("specials")]
        [AcceptVerbs("Get")]
        public IEnumerable<Special> GetSpecials()
        {
            return _repo.GetAllSpecials();
        }

        [Route("featuredvehicles")]
        [AcceptVerbs("Get")]
        public IEnumerable<Vehicle> GetFeaturedVehicles()
        {
            return _repo.GetAllFeaturedVehicles();
        }

        [Route("contactus")]
        [AcceptVerbs("POST")]
        public void AddContacUs(ContactUs x) => _repo.AddContactUs(x);

        [Route("searchnew")]
        [AcceptVerbs("GET")]
        public List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            return _repo.SearchNew(searchText, minPrice, maxPrice, minYear, maxYear);
        }

        [Route("searchused")]
        [AcceptVerbs("GET")]
        public List<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            return _repo.SearchUsed(searchText, minPrice, maxPrice, minYear, maxYear);
        }
        [Route("searchsales")]
        [AcceptVerbs("GET")]
        public List<Vehicle> SearchAll(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            return _repo.SearchAll(searchText, minPrice, maxPrice, minYear, maxYear);
        }
        [Route("purchase")]
        [AcceptVerbs("POST")]
        public void AddPurchasedVehicle(PurchasedVehicle x)
        {
            _repo.AddPurchasedVehicle(x);
        }
        [Route("getbyvin")]
        [AcceptVerbs("GET")]
        public Vehicle GetByVIN(string VIN)
        {
            return _repo.GetVehicleByVIN(VIN);
        }
        [Route("geteasyeditbyvin")]
        [AcceptVerbs("GET")]
        public EasyEditVehicle GetEasyEditByVIN(string VIN)
        {
            return _repo.GetEasyEditByVIN(VIN);
        }
        [Route("getallmakes")]
        [AcceptVerbs("GET")]
        public List<Make> GetMakes()
        {
            return _repo.GetMakes();
        }
        [Route("getallmodels")]
        [AcceptVerbs("GET")]
        public List<Model> GetModels(int makeId)
        {
            return _repo.GetModels(makeId);
        }
        [Route("getbodystyle")]
        [AcceptVerbs("GET")]
        public string GetBodyStyle(int modelId)
        {
            return _repo.GetBodyStyle(modelId);
        }
        [Route("getallcolors")]
        [AcceptVerbs("GET")]
        public List<Color> GetAllColors()
        {
            return _repo.GetAllColors();
        }
        [Route("savenewvehicle")]
        [AcceptVerbs("POST")]
        public void SaveNewVehicle(string vin, string year, int modelId,
    int exColorId, int inColorId, string transmission, int mileage,
    decimal mSRP, decimal salePrice, string description)
        {
            _repo.SaveNewVehicle(vin, year, modelId, exColorId, inColorId, transmission, mileage, mSRP, salePrice, description);
        }


        [Route("editvehicle")]
        [AcceptVerbs("POST")]
        public void EditVehicle(string vin, string year, int modelId,
    int exColorId, int inColorId, string transmission, int mileage,
    decimal mSRP, decimal salePrice, string description, bool featured)
        {
            _repo.EditVehicle(vin, year, modelId, exColorId, inColorId, transmission, mileage, mSRP, salePrice, description, featured);
        }
        [Route("deletevehicle")]
        [AcceptVerbs("POST")]
        public void DeleteVehicle(string VIN)
        {
            _repo.DeleteVehicle(VIN);
            string path = "C:\\Users\\moor0\\source\\repos\\CarDealershipMasteryTheSecond\\CarDealershipTheSecond\\Images\\Vehicles\\";
            path += VIN + ".jpg";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        [Route("savenewmake")]
        [AcceptVerbs("POST")]
        public void AddNewMake(string Name, string User)
        {
            _repo.AddNewMake(Name, User);
        }
        [Route("getallmodelsanymake")]
        [AcceptVerbs("GET")]
        public List<ModelDisplay> GetFullModelList()
        {
            return _repo.GetFullModelList();
        }
        [Route("savenewmodel")]
        [AcceptVerbs("POST")]
        public void SaveNewModel(string name, int makeId, string user, int styleId)
        {
            _repo.SaveNewModel(name, makeId, user, styleId);
        }
        [Route("deletespecial")]
        [AcceptVerbs("POST")]
        public void DeleteSpecial(string specialTitle)
        {
            _repo.DeleteSpecial(specialTitle);
        }

        [Route("savenewspecial")]
        [AcceptVerbs("POST")]
        public void SaveNewSpecial(string specialTitle, string description)
        {
            _repo.SaveNewSpecial(specialTitle, description);
        }
        [Route("usedinventoryitems")]
        [AcceptVerbs("GET")]
        public List<InventoryReportItem> InventoryItems()
        {
            List<Vehicle> all = new List<Vehicle>();
            foreach (Vehicle x in _repo.GetUnsoldVehicles())
            {
                if (x.Mileage >= 1000)
                {
                    all.Add(x);
                }
            }
            List<InventoryReportItem> result = new List<InventoryReportItem>();

            foreach (Vehicle x in all)
            {
                bool inlist = false;
                foreach (InventoryReportItem y in result)
                {
                    if (int.Parse(x.Year) == y.Year && x.Make == y.Make && x.Model == y.Model)
                    {
                        y.Count++;
                        y.StockValue += x.MSRP;
                        inlist = true;
                    }
                }
                if (!inlist)
                {
                    result.Add(new InventoryReportItem { Count = 1, Make = x.Make, Model = x.Model, StockValue = x.MSRP, Year = int.Parse(x.Year) });
                }
            }
            return result;
        }

        [Route("newinventoryitems")]
        [AcceptVerbs("GET")]
        public List<InventoryReportItem> NewInventoryItems()
        {
            List<Vehicle> all = new List<Vehicle>();
            foreach (Vehicle x in _repo.GetUnsoldVehicles())
            {
                if (x.Mileage < 1000)
                {
                    all.Add(x);
                }
            }
            List<InventoryReportItem> result = new List<InventoryReportItem>();

            foreach (Vehicle x in all)
            {
                bool inlist = false;
                foreach (InventoryReportItem y in result)
                {
                    if (int.Parse(x.Year) == y.Year && x.Make == y.Make && x.Model == y.Model)
                    {
                        y.Count++;
                        y.StockValue += x.MSRP;
                        inlist = true;
                    }
                }
                if (!inlist)
                {
                    result.Add(new InventoryReportItem { Count = 1, Make = x.Make, Model = x.Model, StockValue = x.MSRP, Year = int.Parse(x.Year) });
                }
            }
            return result;
        }

        [Route("salesreportitems")]
        [AcceptVerbs("GET")]
        public List<SaleReportItem> SaleReportItems(string user, string fromDate, string toDate)
        {
            List<SaleReportItem> result = new List<SaleReportItem>();
            List<PurchasedVehicle> all;
            if (user.ToLower() != "all")
            {
                all = _repo.GetPurchasedVehicles(user);
            }
            else
            {
                all = _repo.GetPurchasedVehicles();
            }
            foreach (PurchasedVehicle x in all)
            {
                if (x.SaleDate < DateTime.Parse(fromDate) || x.SaleDate > DateTime.Parse(toDate))
                {
                    continue;
                }
                bool inlist = false;
                foreach (SaleReportItem y in result)
                {
                    if (x.Salesperson == y.User)
                    {
                        y.CountSales++;
                        y.TotalSales += x.PurchasePrice;
                        inlist = true;
                    }
                }
                if (!inlist)
                {
                    result.Add(new SaleReportItem { TotalSales = x.PurchasePrice, User = x.Salesperson, CountSales = 1 });
                }
            }
            return result;
        }
        [Route("userswithsales")]
        [AcceptVerbs("GET")]
        public List<string> GetActiveSalespeople()
        {
            List<string> result = new List<string>();
            foreach(PurchasedVehicle x in _repo.GetPurchasedVehicles())
            {
                if (!result.Contains(x.Salesperson))
                {
                    result.Add(x.Salesperson);
                }
            }
            return result;
        }
        [Route("getallstyles")]
        [AcceptVerbs("GET")]
        public List<Style> GetStyles()
        {
            return _repo.GetBodyStyles();
        }
        [Route("getfinancetypes")]
        [AcceptVerbs("GET")]
        public List<FinanceType> GetFinanceTypes()
        {
            return _repo.GetFinanceTypes();
        }
        [Route("getactivevins")]
        [AcceptVerbs("GET")]
        public List<string> GetActiveVins()
        {
            return _repo.GetActiveVINS();
        }
    }
}
