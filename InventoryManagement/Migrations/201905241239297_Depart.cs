namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Depart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "UpdateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Departments", "UpdatedBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "UpdatedBy");
            DropColumn("dbo.Departments", "UpdateDateTime");
        }
    }
}
