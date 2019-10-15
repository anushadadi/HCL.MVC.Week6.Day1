namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieCs");
        }
    }
}
