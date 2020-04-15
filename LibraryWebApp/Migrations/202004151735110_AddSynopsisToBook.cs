namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSynopsisToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Synopsis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Synopsis");
        }
    }
}
