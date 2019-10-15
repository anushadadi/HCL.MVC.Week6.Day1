namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembership_Type : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Membership_Type(Name,Duration,SignupFee,Discount) values('Yearly',12,1200,20)");
            Sql("Insert Membership_Type(Name,Duration,SignupFee,Discount) values('Half-Yearly',6,1200,15)");
            Sql("Insert Membership_Type(Name,Duration,SignupFee,Discount) values('Quarterly',3,1200,10)");
            Sql("Insert Membership_Type(Name,Duration,SignupFee,Discount) values('PasAsUGo',0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
