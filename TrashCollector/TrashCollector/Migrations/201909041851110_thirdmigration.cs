namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "phoneNumber");
            DropColumn("dbo.Employees", "userName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "userName", c => c.String());
            AddColumn("dbo.Customers", "phoneNumber", c => c.Int(nullable: false));
        }
    }
}
