using CarDealershipTheSecond.Models;
using CarDealershipTheSecond.Models.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CarDealershipTheSecond.Data
{
    public class ADORepository : IRepository
    {
        public List<string> GetActiveVINS()
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VINSGetActive",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(
                            dr["VIN"].ToString());
                    }
                }
            }
            return result;
        }
        public void AddContactUs(ContactUs x)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "ContactUsAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@contactName", x.ContactName);
                cmd.Parameters.AddWithValue("@contactPhone", x.ContactPhone);
                cmd.Parameters.AddWithValue("@contactEmail", x.ContactEmail);
                cmd.Parameters.AddWithValue("@contactMessage", x.ContactMessage);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddNewMake(string name, string user)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "MakeAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@makeName", name);
                cmd.Parameters.AddWithValue("@creator", user);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddPurchasedVehicle(PurchasedVehicle x)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "PurchasedVehicleAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VIN", x.VIN);
                cmd.Parameters.AddWithValue("@customerName", x.CustomerName);
                cmd.Parameters.AddWithValue("@street1", x.Street1);
                cmd.Parameters.AddWithValue("@street2", x.Street2);
                cmd.Parameters.AddWithValue("@state", x.State);
                cmd.Parameters.AddWithValue("@zip", x.Zip);
                cmd.Parameters.AddWithValue("@email", x.Email);
                cmd.Parameters.AddWithValue("@phone", x.Phone);
                cmd.Parameters.AddWithValue("@purchasePrice", x.PurchasePrice);
                cmd.Parameters.AddWithValue("@financeTypeId", x.FinanceTypeId);
                cmd.Parameters.AddWithValue("@salesperson", x.Salesperson);
                cmd.Parameters.AddWithValue("@city", x.City);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<FinanceType> GetFinanceTypes()
        {
            List<FinanceType> result = new List<FinanceType>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "FinanceTypesGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new FinanceType
                        {
                            FinanceTypeId = int.Parse(dr["FinanceTypeId"].ToString()),
                            FinanceTypeName = dr["FinanceTypeName"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public void DeleteSpecial(string specialTitle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "SpecialDelete",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@specialTitle", specialTitle);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVehicle(string vin)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehicleDelete",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@vin", vin);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditVehicle(string vin, string year, int modelId, int exColorId, int inColorId, string transmission, int mileage, decimal mSRP, decimal salePrice, string description, bool featured)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehicleEdit",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@vin", vin);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@exColor", exColorId);
                cmd.Parameters.AddWithValue("@inColor", inColorId);
                cmd.Parameters.AddWithValue("@transmission", transmission);
                cmd.Parameters.AddWithValue("@mileage", mileage);
                cmd.Parameters.AddWithValue("@mSRP", mSRP);
                cmd.Parameters.AddWithValue("@salePrice", salePrice);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@featured", featured);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Color> GetAllColors()
        {
            List<Color> result = new List<Color>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "ColorsGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Color
                        {
                            ColorId = int.Parse(dr["ColorId"].ToString()),
                            ColorName = dr["ColorName"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            List<Vehicle> result = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehiclesGetFeatured",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        bool featured = true;
                        if (dr["Featured"].ToString() == "0")
                        {
                            featured = false;
                        }
                        result.Add(new Vehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            Year = dr["Year"].ToString(),
                            Make = dr["Make"].ToString(),
                            Model = dr["Model"].ToString(),
                            ExColor = dr["ExColor"].ToString(),
                            InColor = dr["InColor"].ToString(),
                            Style = dr["Style"].ToString(),
                            Transmission = dr["Transmission"].ToString(),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            SalePrice = decimal.Parse(dr["SalePrice"].ToString()),
                            Description = dr["Description"].ToString(),
                            Featured = featured
                        });
                    }
                }
            }
            return result;
        }

        public List<Special> GetAllSpecials()
        {
            List<Special> result = new List<Special>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "SpecialsGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Special
                        {
                            SpecialTitle = dr["SpecialTitle"].ToString(),
                            SpecialDescription = dr["SpecialDescription"].ToString()
                        });
                    }
                }
            }
            return result;
        }
        public string GetBodyStyle(int modelId)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "GetBodyStyle",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@modelId", modelId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = dr["StyleName"].ToString();
                    }
                }
            }
            return result;
        }

        public List<Style> GetBodyStyles()
        {
            List<Style> result = new List<Style>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "StylesGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Style
                        {
                            StyleId = int.Parse(dr["StyleId"].ToString()),
                            StyleName = dr["StyleName"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public EasyEditVehicle GetEasyEditByVIN(string vin)
        {
            EasyEditVehicle result = new EasyEditVehicle();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "GetEasyEditByVIN",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@vin", vin);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.VIN = dr["VIN"].ToString();
                        result.Year = dr["Year"].ToString();
                        result.MakeId = int.Parse(dr["MakeId"].ToString());
                        result.ModelId = int.Parse(dr["ModelId"].ToString());
                        result.ExColorId = int.Parse(dr["ExColor"].ToString());
                        result.InColorId = int.Parse(dr["InColor"].ToString());
                        result.Transmission = dr["Transmission"].ToString();
                        result.Mileage = int.Parse(dr["Mileage"].ToString());
                        result.MSRP = decimal.Parse(dr["MSRP"].ToString());
                        result.SalePrice = decimal.Parse(dr["SalePrice"].ToString());
                        result.Description = dr["Description"].ToString();
                        result.Featured = bool.Parse(dr["Featured"].ToString());
                    }
                }
            }
            return result;
        }

        public List<ModelDisplay> GetFullModelList()
        {
            List<ModelDisplay> result = new List<ModelDisplay>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "ModelsGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new ModelDisplay()
                        {
                            ModelName = dr["ModelName"].ToString(),
                            MakeName = dr["MakeName"].ToString(),
                            Creator = dr["Creator"].ToString(),
                            DateAdded = DateTime.Parse(dr["DateAdded"].ToString())
                        });
                    }
                }
            }
            return result;
        }

        public List<Make> GetMakes()
        {
            List<Make> result = new List<Make>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "MakesGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Make
                        {
                            MakeId = int.Parse(dr["MakeId"].ToString()),
                            MakeName = dr["MakeName"].ToString(),
                            Creator = dr["Creator"].ToString(),
                            DateAdded = DateTime.Parse(dr["DateAdded"].ToString()),
                        });
                    }
                }
            }
            return result;
        }

        public List<Model> GetModels(int makeId)
        {
            List<Model> result = new List<Model>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "ModelsGetByMakeId",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@makeId", makeId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Model
                        {
                            MakeId = int.Parse(dr["MakeId"].ToString()),
                            ModelId = int.Parse(dr["ModelId"].ToString()),
                            Creator = dr["Creator"].ToString(),
                            StyleId = int.Parse(dr["StyleId"].ToString()),
                            ModelName = dr["ModelName"].ToString(),
                            DateAdded = DateTime.Parse(dr["DateAdded"].ToString()),
                        });
                    }
                }
            }
            return result;
        }

        public List<PurchasedVehicle> GetPurchasedVehicles()
        {
            List<PurchasedVehicle> result = new List<PurchasedVehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "PurchasedVehiclesGetAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new PurchasedVehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                            Street1 = dr["Street1"].ToString(),
                            Street2 = dr["Street2"].ToString(),
                            City = dr["City"].ToString(),
                            State = dr["StateAbbreviation"].ToString(),
                            Zip = dr["Zip"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            PurchasePrice = decimal.Parse(dr["PurchasePrice"].ToString()),
                            FinanceTypeId = int.Parse(dr["FinanceTypeId"].ToString()),
                            SaleDate = DateTime.Parse(dr["SaleDate"].ToString()),
                            Salesperson = dr["Salesperson"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public List<PurchasedVehicle> GetPurchasedVehicles(string user)
        {
            List<PurchasedVehicle> result = new List<PurchasedVehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "PurchasedVehicleGetBySalesperson",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@salesperson", user);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new PurchasedVehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                            Street1 = dr["Street1"].ToString(),
                            Street2 = dr["Street2"].ToString(),
                            City = dr["City"].ToString(),
                            State = dr["StateAbbreviation"].ToString(),
                            Zip = dr["Zip"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            PurchasePrice = decimal.Parse(dr["PurchasePrice"].ToString()),
                            FinanceTypeId = int.Parse(dr["FinanceTypeId"].ToString()),
                            SaleDate = DateTime.Parse(dr["SaleDate"].ToString()),
                            Salesperson = dr["Salesperson"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public List<Vehicle> GetUnsoldVehicles()
        {
            List<Vehicle> result = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehiclesGetAllUnsold",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        bool featured = true;
                        if (dr["Featured"].ToString() == "0")
                        {
                            featured = false;
                        }
                        result.Add(new Vehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            Year = dr["Year"].ToString(),
                            Make = dr["Make"].ToString(),
                            Model = dr["Model"].ToString(),
                            ExColor = dr["ExColor"].ToString(),
                            InColor = dr["InColor"].ToString(),
                            Style = dr["Style"].ToString(),
                            Transmission = dr["Transmission"].ToString(),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            SalePrice = decimal.Parse(dr["SalePrice"].ToString()),
                            Description = dr["Description"].ToString(),
                            Featured = featured
                        });
                    }
                }
            }
            return result;
        }

        public Vehicle GetVehicleByVIN(string VIN)
        {
            Vehicle result = new Vehicle();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehicleGetByVIN",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@vin", VIN);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.VIN = dr["VIN"].ToString();
                        result.Year = dr["Year"].ToString();
                        result.Make = dr["Make"].ToString();
                        result.Model = dr["Model"].ToString();
                        result.ExColor = dr["ExColor"].ToString();
                        result.InColor = dr["InColor"].ToString();
                        result.Style = dr["Style"].ToString();
                        result.Transmission = dr["Transmission"].ToString();
                        result.Mileage = int.Parse(dr["Mileage"].ToString());
                        result.MSRP = decimal.Parse(dr["MSRP"].ToString());
                        result.SalePrice = decimal.Parse(dr["SalePrice"].ToString());
                        result.Description = dr["Description"].ToString();
                        result.Featured = bool.Parse(dr["Featured"].ToString());
                    }
                }
            }
            return result;
        }

        public void SaveNewModel(string name, int makeId, string user, int styleId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "ModelAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@makeId", makeId);
                cmd.Parameters.AddWithValue("@styleId", styleId);
                cmd.Parameters.AddWithValue("@modelName", name);
                cmd.Parameters.AddWithValue("@creator", user);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveNewSpecial(string specialTitle, string description)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "SpecialAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@specialTitle", specialTitle);
                cmd.Parameters.AddWithValue("@specialDescription", description);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveNewVehicle(string vin, string year, int modelId, int exColorId, int inColorId, string transmission, int mileage, decimal mSRP, decimal salePrice, string description)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehicleAdd",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@vin", vin.ToUpper());
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@exColor", exColorId);
                cmd.Parameters.AddWithValue("@inColor", inColorId);
                cmd.Parameters.AddWithValue("@transmission", transmission);
                cmd.Parameters.AddWithValue("@mileage", mileage);
                cmd.Parameters.AddWithValue("@mSRP", mSRP);
                cmd.Parameters.AddWithValue("@salePrice", salePrice);
                cmd.Parameters.AddWithValue("@description", description);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> SearchAll(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            List<Vehicle> result = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehiclesSearchAll",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@searchText", searchText);
                cmd.Parameters.AddWithValue("@minPrice", minPrice);
                cmd.Parameters.AddWithValue("@minYear", minYear);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@maxYear", maxYear);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Vehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            Year = dr["Year"].ToString(),
                            Make = dr["Make"].ToString(),
                            Model = dr["Model"].ToString(),
                            ExColor = dr["ExColor"].ToString(),
                            InColor = dr["InColor"].ToString(),
                            Style = dr["Style"].ToString(),
                            Transmission = dr["Transmission"].ToString(),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            SalePrice = decimal.Parse(dr["SalePrice"].ToString()),
                            Description = dr["Description"].ToString(),
                            Featured = bool.Parse(dr["Featured"].ToString())
                        }) ;
                    }
                }
            }
            return result;
        }

        public List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if(searchText == null)
            {
                searchText = "";
            }
            List<Vehicle> result = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehiclesSearchNew",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@searchText", searchText);
                cmd.Parameters.AddWithValue("@minPrice", minPrice);
                cmd.Parameters.AddWithValue("@minYear", minYear);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@maxYear", maxYear);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if(dr["VIN"] != DBNull.Value)
                        {
                            result.Add(new Vehicle
                            {

                                VIN = dr["VIN"].ToString(),
                                Year = dr["Year"].ToString(),
                                Make = dr["Make"].ToString(),
                                Model = dr["Model"].ToString(),
                                ExColor = dr["ExColor"].ToString(),
                                InColor = dr["InColor"].ToString(),
                                Style = dr["Style"].ToString(),
                                Transmission = dr["Transmission"].ToString(),
                                Mileage = int.Parse(dr["Mileage"].ToString()),
                                MSRP = decimal.Parse(dr["MSRP"].ToString()),
                                SalePrice = decimal.Parse(dr["SalePrice"].ToString()),
                                Description = dr["Description"].ToString(),
                                Featured = bool.Parse(dr["Featured"].ToString())
                            });
                        }
                        
                    }
                }
            }
            return result;
        }

        public List<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            List<Vehicle> result = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "VehiclesSearchUsed",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@searchText", searchText);
                cmd.Parameters.AddWithValue("@minPrice", minPrice);
                cmd.Parameters.AddWithValue("@minYear", minYear);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@maxYear", maxYear);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Vehicle
                        {
                            VIN = dr["VIN"].ToString(),
                            Year = dr["Year"].ToString(),
                            Make = dr["Make"].ToString(),
                            Model = dr["Model"].ToString(),
                            ExColor = dr["ExColor"].ToString(),
                            InColor = dr["InColor"].ToString(),
                            Style = dr["Style"].ToString(),
                            Transmission = dr["Transmission"].ToString(),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            SalePrice = decimal.Parse(dr["SalePrice"].ToString()),
                            Description = dr["Description"].ToString(),
                            Featured = bool.Parse(dr["Featured"].ToString())
                        });
                    }
                }
            }
            return result;
        }
    }
}