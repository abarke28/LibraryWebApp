namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToNewsletterToReader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Readers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Readers", "IsSubscribedToNewsletter");
        }
    }
}
