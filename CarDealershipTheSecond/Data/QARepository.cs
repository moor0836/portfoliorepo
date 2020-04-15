using CarDealershipTheSecond.Models;
using CarDealershipTheSecond.Models.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace CarDealershipTheSecond.Data
{
    public class QARepository : IRepository
    {

        private static List<Make> _makes = new List<Make>()
        {
            new Make {MakeId = 1, MakeName = "Honda", Creator = "QAAdmin"},
            new Make {MakeId = 2, MakeName = "Toyota", Creator = "QAAdmin"},
            new Make {MakeId = 3, MakeName = "Hyundai", Creator = "QAAdmin"}
        };

        private static List<Style> _styles = new List<Style>()
        {
            new Style {StyleId = 1, StyleName = "Truck"},
            new Style {StyleId = 2, StyleName = "Car"},
            new Style {StyleId = 3, StyleName = "SUV"}
        };

        private static List<Model> _models = new List<Model>()
        {
            new Model {ModelId = 1, ModelName = "Civic", MakeId = 1, StyleId=2, Creator = "QAAdmin"},
            new Model {ModelId = 2, ModelName = "Tacoma", MakeId= 2, StyleId=1, Creator = "QAAdmin"},
            new Model {ModelId = 3, ModelName = "Accent", MakeId = 3, StyleId=2, Creator = "QAAdmin"}
        };

        private static List<Color> _colors = new List<Color>()
        {
            new Color {ColorId = 1, ColorName = "Gray"},
            new Color {ColorId = 2, ColorName = "Black"},
            new Color {ColorId = 3, ColorName = "Red"},
            new Color {ColorId = 4, ColorName = "Blue"},
            new Color {ColorId = 5, ColorName = "White"},
            new Color {ColorId = 6, ColorName = "Silver"},
            new Color {ColorId = 7, ColorName = "Beige"}
        };

        private static List<Vehicle> _vehicles = new List<Vehicle>()
        {
            new Vehicle {VIN = "3TMCZ5AN9LM321661", ExColor = "Black", InColor = "Black", Featured = true, Mileage = 1, MSRP = 44013, SalePrice = 41170, Description = "Midnight Black 2020 Toyota Tacoma TRD Offroad V6 4WD 6-Speed Automatic V6 Experience the Heintz Toyota Difference * Professionally Reconditioned * Full Mechanical Inspec, 4WD.", Transmission="Automatic", Year = "2020", Make="Toyota", Model = "Tacoma", Style = "Truck"},
            new Vehicle {VIN = "3TMCZ5AN7GM033983", ExColor = "Gray", InColor="Black", Featured = true, MSRP = 32001, SalePrice = 30875, Mileage = 12639, Transmission = "Automatic", Year = "2016", Description = "This Local One Owner, Tacoma TRD Off Road has Only 12,600 Miles!! Hard To Find Compact Crew Cab 4X4!!!" , Make= "Toyota", Model = "Tacoma", Style = "Truck"},
            new Vehicle {VIN = "2HGFB6E50EH704800", ExColor = "Red", InColor = "Beige", Featured = false, Transmission = "Manual", Mileage = 64916, MSRP = 14000, SalePrice = 12499, Year = "2014", Description = "Bluetooth, Backup Camera, Sunroof/Moonroof, Navigation System, Alloy Wheels", Make="Honda", Model = "Civic", Style = "Car"},
            new Vehicle {VIN = "2HGFC2F6XKH593603", ExColor = "Blue", InColor = "Gray", Featured = true, Mileage = 1, Transmission = "Automatic", Year = "2019", MSRP = 21280, SalePrice = 20350, Description = "Beautiful new Honda Civic, with continuously variable transmission, see it to believe it!!", Make="Honda", Model = "Civic", Style = "Car"},
            new Vehicle {VIN = "KMHCT4AE1DU391644", ExColor = "Silver", InColor = "Gray", Featured = false, Mileage = 106097, Transmission = "Automatic", Year = "2013", MSRP = 3200, SalePrice =2995, Description = "Perfect first vehicle for the new driver in your house - reliable and affordable!", Make = "Hyundai", Model="Accent", Style = "Car"},
            new Vehicle {VIN = "3KPC24A37KE063128", ExColor = "White", InColor = "Black", Featured = true, Mileage = 14, MSRP = 13000, SalePrice = 11999, Year="2019", Transmission = "Automatic", Description = "Brand new, sharply discounted Hyundai Accent in a clean white ready for pickup today", Make = "Hyundai", Model="Accent", Style = "Car"}
        };

        private static List<PurchasedVehicle> _purchasedVehicles = new List<PurchasedVehicle>();

        private static List<Special> _specials = new List<Special>()
        {
            new Special {SpecialTitle = "Veterans' Sale", SpecialDescription = "Calling all veterans - take 5% off any SalePrice now through Veteran's Day!"},
            new Special {SpecialTitle = "COVID-19 Deal", SpecialDescription = "Caronavirus got you down? Want to get out without exposing yourself to the dangers of public transit? Trade in your transit card for 6% off sale price of any used vehicle! Now through the lifting of stay-at-home order in MN"},
            new Special {SpecialTitle = "Teachers' Special", SpecialDescription = "Teachers, who have been underappreciated so long, it's time we recognize you too! Bring in your school ID for 7% off the price of ANY vehicle! Now through the new school year."}
        };

        private static List<ContactUs> _contactus = new List<ContactUs>()
        {
            new ContactUs {ContactName="Paul Moore", ContactEmail="something@somewhere.com", ContactPhone="333-333-3333", ContactMessage="I am interested in the cheapest and least desirable vehicle, so it won't get stolen..."}
        };
        private static List<FinanceType> _financeTypes = new List<FinanceType>()
        {
            new FinanceType {FinanceTypeId = 1, FinanceTypeName = "Bank Finance"},
            new FinanceType {FinanceTypeId = 2, FinanceTypeName = "Cash"},
            new FinanceType {FinanceTypeId = 3, FinanceTypeName = "Dealer Finance"}
        };

        public List<FinanceType> GetFinanceTypes()
        {
            return _financeTypes;
        }
        public List<Style> GetBodyStyles()
        {
            return _styles;
        }
        public List<string> GetActiveVINS()
        {
            List<string> result = new List<string>();
            foreach (Vehicle x in _vehicles)
            {
                result.Add(x.VIN);
            }
            return result;
        }
        public List<Vehicle> GetUnsoldVehicles()
        {
            List<Vehicle> result = new List<Vehicle>();
            List<string> purchasedVehicles = new List<string>();
            foreach (PurchasedVehicle x in _purchasedVehicles)
            {
                purchasedVehicles.Add(x.VIN);
            }
            foreach (Vehicle x in _vehicles)
            {
                if (!purchasedVehicles.Contains(x.VIN))
                {
                    result.Add(x);
                }
            }
            return result;
        }
        public List<Make> GetMakes()
        {
            return _makes;
        }
        public List<ModelDisplay> GetFullModelList()
        {
            List<ModelDisplay> result = new List<ModelDisplay>();
            foreach(Model x in _models)
            {
                result.Add(new ModelDisplay()
                {
                    ModelName = x.ModelName,
                    DateAdded = x.DateAdded,
                    MakeName = _makes.FirstOrDefault(y=>x.MakeId == y.MakeId).MakeName,
                    Creator = x.Creator
                });
            }
            return result;
        }
        public void AddNewMake(string name, string user)
        {
            int index = 1;
            foreach (Make x in _makes)
            {
                if (x.MakeId >= index)
                    index = x.MakeId + 1;
            }
            _makes.Add(new Make { MakeId = index, MakeName = name, Creator = user});
        }

        public List<Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            return GetUnsoldVehicles().Where(x => x.Featured == true).ToList();
        }
        public void AddContactUs(ContactUs x)
        {
            _contactus.Add(x);
        }

        public List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            var result = GetUnsoldVehicles().Where(x => (x.Mileage < 1000 && 
            (
                x.Make.ToLower().Contains(searchText.ToLower()) ||
                x.Model.ToLower().Contains(searchText.ToLower()) ||
                x.Year.Contains(searchText)) &&
                int.Parse(x.Year) >= minYear &&
                int.Parse(x.Year) <= maxYear
                &&
                (x.SalePrice >= minPrice &&
                x.SalePrice <= maxPrice)
                )
                ).ToList();

            return result;
        }
        public List<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            return GetUnsoldVehicles().Where(x => (x.Mileage >= 1000 &&
            (
                x.Make.ToLower().Contains(searchText.ToLower()) ||
                x.Model.ToLower().Contains(searchText.ToLower()) ||
                x.Year.Contains(searchText)) &&
                int.Parse(x.Year) >= minYear &&
                int.Parse(x.Year) <= maxYear &&
                (x.SalePrice >= minPrice &&
                x.SalePrice <= maxPrice))
                ).ToList();
        }
        public List<Vehicle> SearchAll(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            return GetUnsoldVehicles().Where(x => (
            (
                x.Make.ToLower().Contains(searchText.ToLower()) ||
                x.Model.ToLower().Contains(searchText.ToLower()) ||
                x.Year.Contains(searchText)) &&
                int.Parse(x.Year) >= minYear &&
                int.Parse(x.Year) <= maxYear &&
                (x.SalePrice >= minPrice &&
                x.SalePrice <= maxPrice))
                ).ToList();
        }
        public Vehicle GetVehicleByVIN(string VIN)
        {
            return _vehicles.FirstOrDefault(x => x.VIN == VIN);
        }
        public EasyEditVehicle GetEasyEditByVIN(string vin)
        {
            Vehicle x = GetVehicleByVIN(vin);
            return new EasyEditVehicle
            {
                VIN = x.VIN,
                MakeId = _models.FirstOrDefault(y=> y.ModelName == x.Model).MakeId,
                ModelId = _models.FirstOrDefault(y => y.ModelName == x.Model).ModelId,
                ExColorId = _colors.FirstOrDefault(y => y.ColorName == x.ExColor).ColorId,
                InColorId = _colors.FirstOrDefault(y => y.ColorName == x.InColor).ColorId,
                Transmission = x.Transmission,
                Mileage = x.Mileage,
                MSRP = x.MSRP,
                SalePrice = x.SalePrice,
                Description = x.Description,
                Featured = x.Featured
            };
        }
        public void AddPurchasedVehicle(PurchasedVehicle x)
        {
            _purchasedVehicles.Add(x);
        }
        public List<PurchasedVehicle> GetPurchasedVehicles()
        {
            return _purchasedVehicles;
        }
        public List<PurchasedVehicle> GetPurchasedVehicles(string user)
        {
            return _purchasedVehicles.Where(x => x.Salesperson == user).ToList();
        }
        public List<Model> GetModels(int makeId)
        {
            return _models.Where(x => x.MakeId == makeId).ToList();
        }
        public string GetBodyStyle(int modelId)
        {
            return _styles.FirstOrDefault(x => x.StyleId == (_models.FirstOrDefault(y => y.ModelId == modelId).StyleId)).StyleName;
        }
        public List<Color> GetAllColors()
        {
            return _colors;
        }
        public void SaveNewVehicle(string vin, string year, int modelId, 
    int exColorId, int inColorId, string transmission, int mileage, 
    decimal mSRP, decimal salePrice, string description)
        {
            Model model = _models.FirstOrDefault(x => x.ModelId == modelId);
            string makeName = _makes.FirstOrDefault(x => x.MakeId == model.MakeId).MakeName;
            string style = _styles.FirstOrDefault(x => x.StyleId == model.StyleId).StyleName;
            string exColor = _colors.FirstOrDefault(x => x.ColorId == exColorId).ColorName;
            string inColor = _colors.FirstOrDefault(x => x.ColorId == inColorId).ColorName;

            _vehicles.Add(new Vehicle
            {
                VIN = vin,
                Year = year,
                Make = makeName,
                Model = model.ModelName,
                ExColor = exColor,
                InColor = inColor,
                Style = style,
                Transmission = transmission,
                Mileage = mileage,
                MSRP = mSRP,
                SalePrice = salePrice,
                Description = description,
                Featured = false
            });
        }
        public void EditVehicle(string vin, string year, int modelId,
    int exColorId, int inColorId, string transmission, int mileage,
    decimal mSRP, decimal salePrice, string description, bool featured)
        {
            DeleteVehicle(vin);
            SaveNewVehicle(vin, year, modelId, exColorId, inColorId, transmission, mileage, mSRP, salePrice, description);
            _vehicles.FirstOrDefault(x => x.VIN == vin).Featured = featured;
        }

        public void DeleteVehicle(string vin)
        {
            _vehicles.RemoveAll(x => x.VIN == vin);
        }
        public void SaveNewModel(string name, int makeId, string user, int styleId)
        {
            int index = 1;
            foreach (Model x in _models)
            {
                if (x.ModelId >= index)
                    index = x.ModelId + 1;
            }
            _models.Add(new Model { ModelId = index, MakeId = makeId, ModelName = name, StyleId = styleId, Creator = user });
        }
        public void DeleteSpecial(string specialTitle)
        {
            _specials.RemoveAll(x => x.SpecialTitle == specialTitle);
        }
        public void SaveNewSpecial(string specialTitle, string description)
        {
            _specials.Add(new Special { SpecialDescription = description, SpecialTitle = specialTitle });
        }
    }
}
