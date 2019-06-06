namespace InventoryManagement.Migrations
{
    using InventoryManagement.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManagement.DAL.InventoryManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "InventoryManagement.DAL.InventoryManagementContext";
        }

        protected override void Seed(InventoryManagement.DAL.InventoryManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            String[] roleNames = { "Admin", "Employee" };

            IdentityResult roleResult;
            foreach(var roleName in roleNames){
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName)); 
                }
            }
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("4ff65b80-fb59-426a-969e-cc10cd2ad8e0", "Admin");
        }
    }
}
