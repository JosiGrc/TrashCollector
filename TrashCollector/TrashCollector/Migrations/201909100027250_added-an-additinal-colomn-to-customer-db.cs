namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanadditinalcolomntocustomerdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "additionalPickup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "additionalPickup");
        }
    }
}
