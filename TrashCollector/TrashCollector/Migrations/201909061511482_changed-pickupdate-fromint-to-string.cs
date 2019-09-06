namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpickupdatefrominttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "pickUpdate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "pickUpdate", c => c.Int(nullable: false));
        }
    }
}
