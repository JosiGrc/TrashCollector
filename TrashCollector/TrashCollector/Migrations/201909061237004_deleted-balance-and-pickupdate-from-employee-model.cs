namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedbalanceandpickupdatefromemployeemodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "balance");
            DropColumn("dbo.Employees", "pickUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "pickUpdate", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "balance", c => c.Double(nullable: false));
        }
    }
}
