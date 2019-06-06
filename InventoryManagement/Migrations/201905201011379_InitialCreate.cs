namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allotments",
                c => new
                    {
                        AllotmentID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllotmentID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Firstname = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Active = c.Boolean(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        RegisterId = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        ReOrderLabel = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Active = c.Boolean(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Active = c.Boolean(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WithDraws",
                c => new
                    {
                        WithDrawID = c.Int(nullable: false, identity: true),
                        AllotmentID = c.Int(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WithDrawID)
                .ForeignKey("dbo.Allotments", t => t.AllotmentID, cascadeDelete: true)
                .Index(t => t.AllotmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WithDraws", "AllotmentID", "dbo.Allotments");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Requests", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Requests", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Allotments", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Allotments", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.WithDraws", new[] { "AllotmentID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Requests", new[] { "ItemID" });
            DropIndex("dbo.Requests", new[] { "EmployeeID" });
            DropIndex("dbo.Purchases", new[] { "ItemID" });
            DropIndex("dbo.Items", new[] { "SupplierID" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Allotments", new[] { "ItemID" });
            DropIndex("dbo.Allotments", new[] { "EmployeeID" });
            DropTable("dbo.WithDraws");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Requests");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Allotments");
        }
    }
}
