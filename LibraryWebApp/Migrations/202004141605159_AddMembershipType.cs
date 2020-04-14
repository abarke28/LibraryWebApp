namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        UpfrontFee = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
            
            AddColumn("dbo.Readers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Readers", "MembershipTypeId");
            AddForeignKey("dbo.Readers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Readers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Readers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Readers", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
