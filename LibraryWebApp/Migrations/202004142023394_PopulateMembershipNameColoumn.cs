namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipNameColoumn : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Pay As You Go' WHERE MembershipTypeId = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = '1 Month' WHERE MembershipTypeId = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = '3 Months' WHERE MembershipTypeId = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Annual' WHERE MembershipTypeId = 4");
        }
        
        public override void Down()
        {
        }
    }
}
