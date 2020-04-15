using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VendingMachineTheSecond.Models.EF
{
    public class VendingItemCatalogueEntities : DbContext
    {
        public VendingItemCatalogueEntities()
            : base("VendingItemCatalogue")
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}