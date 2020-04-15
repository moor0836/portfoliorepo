namespace VendingMachineTheSecond.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VendingMachineTheSecond.Models.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<VendingMachineTheSecond.Models.EF.VendingItemCatalogueEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VendingMachineTheSecond.Models.EF.VendingItemCatalogueEntities context)
        {
            context.Items.AddOrUpdate(
                g => g.id,
            new Item { id = 1, Name = "Reeses", Price = 2.50M, Quantity = 20 },
            new Item { id = 2, Name = "M&Ms", Price = 1.65M, Quantity = 5243 },
            new Item { id = 3, Name = "Oreos", Price = 2.37M, Quantity = 4 });
            //  This method will be called after migrating to the latest version.
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
