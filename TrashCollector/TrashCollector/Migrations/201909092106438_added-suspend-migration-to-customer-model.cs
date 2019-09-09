namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsuspendmigrationtocustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "suspendPickup", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "suspendPickup");
        }
    }
}
