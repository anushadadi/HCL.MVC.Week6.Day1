namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieCs", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieCs", "Genre", c => c.String());
        }
    }
}
