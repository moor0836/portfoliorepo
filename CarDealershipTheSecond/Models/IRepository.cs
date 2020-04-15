using CarDealershipTheSecond.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipTheSecond.Models
{
    public interface IRepository
    {
        List<Vehicle> GetUnsoldVehicles();
        List<Make> GetMakes();
        List<ModelDisplay> GetFullModelList();
        void AddNewMake(string name, string user);
        List<Special> GetAllSpecials();
        List<Vehicle> GetAllFeaturedVehicles();
        void AddContactUs(ContactUs x);
        List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        List<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        List<Vehicle> SearchAll(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        Vehicle GetVehicleByVIN(string VIN);
        void AddPurchasedVehicle(PurchasedVehicle x);
        List<PurchasedVehicle> GetPurchasedVehicles();
        List<PurchasedVehicle> GetPurchasedVehicles(string user);
        List<Model> GetModels(int makeId);
        string GetBodyStyle(int modelId);
        List<Color> GetAllColors();
        void SaveNewVehicle(string vin, string year, int modelId,
    int exColorId, int inColorId, string transmission, int mileage,
    decimal mSRP, decimal salePrice, string description);
        void EditVehicle(string vin, string year, int modelId,
    int exColorId, int inColorId, string transmission, int mileage,
    decimal mSRP, decimal salePrice, string description, bool featured);
        void DeleteVehicle(string vin);
        void SaveNewModel(string name, int makeId, string user, int styleId);
        void DeleteSpecial(string specialTitle);
        void SaveNewSpecial(string specialTitle, string description);
        EasyEditVehicle GetEasyEditByVIN(string vin);
        List<FinanceType> GetFinanceTypes();

        List<Style> GetBodyStyles();

        List<string> GetActiveVINS();
    }
}
