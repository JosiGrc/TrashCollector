namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "email");
        }
    }
}
