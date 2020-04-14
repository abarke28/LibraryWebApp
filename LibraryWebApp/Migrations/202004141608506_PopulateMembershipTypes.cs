namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (UpfrontFee, DurationInMonths, DiscountRate) VALUES (0,0,0)");
            Sql("INSERT INTO MembershipTypes (UpfrontFee, DurationInMonths, DiscountRate) VALUES (30,1,10)");
            Sql("INSERT INTO MembershipTypes (UpfrontFee, DurationInMonths, DiscountRate) VALUES (90,3,15)");
            Sql("INSERT INTO MembershipTypes (UpfrontFee, DurationInMonths, DiscountRate) VALUES (150,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}