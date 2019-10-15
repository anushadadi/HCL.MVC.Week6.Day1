namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres(Name)values('horror')");
            Sql("Insert Genres(Name)values('family')");
            Sql("Insert Genres(Name)values('comedy')");
            Sql("Insert Genres(Name)values('Inspirational')");

        }
        
        public override void Down()
        {
        }
    }
}
