namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerCs", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerCs", "City");
        }
    }
}
