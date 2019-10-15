namespace HCL.MVC.Week6.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMembership : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerCs", "MemberShipType_Id", "dbo.MemberShipTypes");
            DropForeignKey("dbo.CustomerCs", "MemberShipTypeId_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.CustomerCs", new[] { "MemberShipType_Id" });
            DropIndex("dbo.CustomerCs", new[] { "MemberShipTypeId_Id" });
            CreateTable(
                "dbo.Membership_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Short(nullable: false),
                        SignupFee = c.Double(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.CustomerCs", "MemberShipType_Id");
            DropColumn("dbo.CustomerCs", "MemberShipTypeId_Id");
            DropTable("dbo.MemberShipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Short(nullable: false),
                        SignUPFee = c.Double(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerCs", "MemberShipTypeId_Id", c => c.Int());
            AddColumn("dbo.CustomerCs", "MemberShipType_Id", c => c.Int());
            DropTable("dbo.Membership_Type");
            CreateIndex("dbo.CustomerCs", "MemberShipTypeId_Id");
            CreateIndex("dbo.CustomerCs", "MemberShipType_Id");
            AddForeignKey("dbo.CustomerCs", "MemberShipTypeId_Id", "dbo.MemberShipTypes", "Id");
            AddForeignKey("dbo.CustomerCs", "MemberShipType_Id", "dbo.MemberShipTypes", "Id");
        }
    }
}
