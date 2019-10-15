namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieCs", "AvailableStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieCs", "AvailableStock");
        }
    }
}
