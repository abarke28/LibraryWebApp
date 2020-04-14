namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublishedMonthAndYearToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublishedYear", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "PublishedMonth", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PublishedMonth");
            DropColumn("dbo.Books", "PublishedYear");
        }
    }
}
