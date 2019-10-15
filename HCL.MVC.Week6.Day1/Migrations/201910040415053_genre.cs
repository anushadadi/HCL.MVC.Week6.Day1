namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieCs", "GenreId", c => c.Int(nullable: true));
            CreateIndex("dbo.MovieCs", "GenreId");
            AddForeignKey("dbo.MovieCs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCs", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieCs", new[] { "GenreId" });
            DropColumn("dbo.MovieCs", "GenreId");
        }
    }
}
