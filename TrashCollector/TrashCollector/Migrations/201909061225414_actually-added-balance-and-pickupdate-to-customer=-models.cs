namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actuallyaddedbalanceandpickupdatetocustomermodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "balance", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "pickUpdate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickUpdate");
            DropColumn("dbo.Customers", "balance");
        }
    }
}
