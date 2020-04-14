namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBookPublishedPropsToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "PublishedYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "PublishedMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "PublishedMonth", c => c.Byte(nullable: false));
            AlterColumn("dbo.Books", "PublishedYear", c => c.Byte(nullable: false));
        }
    }
}
