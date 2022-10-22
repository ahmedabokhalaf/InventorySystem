namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BillItems");
            AlterColumn("dbo.BillItems", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BillItems", new[] { "ID", "BillID", "ItemID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BillItems");
            AlterColumn("dbo.BillItems", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BillItems", new[] { "ID", "BillID", "ItemID" });
        }
    }
}
