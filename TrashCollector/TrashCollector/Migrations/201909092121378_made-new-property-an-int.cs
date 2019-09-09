namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madenewpropertyanint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "suspendPickup", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "suspendPickup", c => c.Int(nullable: false));
        }
    }
}
