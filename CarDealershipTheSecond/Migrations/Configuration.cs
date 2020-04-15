namespace CarDealershipTheSecond.Migrations
{
    using CarDealershipTheSecond.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipTheSecond.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealershipTheSecond.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
                r => r.Id,
                new IdentityRole { Name = "Sales" },
                new IdentityRole { Name = "Admin" }
        
            );
            context.Users.AddOrUpdate(
                u => u.Id,
        
                new ApplicationUser { UserName = "admin@cardealership.com", Email = "admin@cardealership.com", EmailConfirmed = true }
            );
            context.SaveChanges();
        }
    }
}
