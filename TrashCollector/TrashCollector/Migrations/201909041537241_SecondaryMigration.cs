namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "zipcode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "zipcode");
        }
    }
}
