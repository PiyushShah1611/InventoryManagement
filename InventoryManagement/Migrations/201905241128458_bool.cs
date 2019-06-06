namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Active", c => c.Int(nullable: false));
        }
    }
}
