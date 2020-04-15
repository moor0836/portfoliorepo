using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VendingMachineTheSecond.Models.EF;

namespace VendingMachineTheSecond.Models
{
    public class ItemRepository
    {
        public static List<Item> GetAll()
        {
            using (var context = new VendingItemCatalogueEntities())
            {
                return context.Items.Select(x => new Item() { id = x.id, Name = x.Name, Price = x.Price, Quantity = x.Quantity }).ToList();
            }
        }
        public static Item Get(int id)
        {
            using (var context = new VendingItemCatalogueEntities())
            {
                return context.Items.Select(x => new Item() { id = x.id, Name = x.Name, Price = x.Price, Quantity = x.Quantity }).FirstOrDefault(x => x.id == id);
            }
        }
        public static ItemVendResult Purchase(int id, decimal payment)
        {
            using (SqlConnection conn = new SqlConnection())
            {


                ItemVendResult result = new ItemVendResult();
                Item item = Get(id);
                if (item.Quantity < 1)
                {
                    result.success = false;
                    result.failureMessage = "Sold out";
                }
                else if (item.Price > payment)
                {
                    result.success = false;
                    decimal difference = item.Price - payment;
                    result.failureMessage = "Please deposit an additional $" + difference.ToString();
                }
                else
                {
                    result.success = true;
                    using (var context = new VendingItemCatalogueEntities())
                    {
                        var itemForUpdate = context.Items.SingleOrDefault(i => i.id == id);
                        if(itemForUpdate != null)
                        {
                            itemForUpdate.Quantity--;
                            context.SaveChanges();
                        }
                    }
                    result.change = payment - item.Price;
                }
                return result;
            }
        }
    }
}