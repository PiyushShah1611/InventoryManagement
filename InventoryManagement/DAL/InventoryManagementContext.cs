using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InventoryManagement.DAL
{
    public class InventoryManagementContext: IdentityDbContext<ApplicationUser>
    {
        public InventoryManagementContext() : base("name=InventoryManagementContext")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Allotment> Allotments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<WithDraw> WithDraws { get; set; }

        public static InventoryManagementContext Create()
        {
            return new InventoryManagementContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<InventoryManagement.Models.Supplier> Supplier { get; set; }
    }
}