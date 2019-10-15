namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerCs", "Membership_TypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.CustomerCs", "Membership_TypeId");
            AddForeignKey("dbo.CustomerCs", "Membership_TypeId", "dbo.Membership_Type", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCs", "Membership_TypeId", "dbo.Membership_Type");
            DropIndex("dbo.CustomerCs", new[] { "Membership_TypeId" });
            DropColumn("dbo.CustomerCs", "Membership_TypeId");
        }
    }
}
