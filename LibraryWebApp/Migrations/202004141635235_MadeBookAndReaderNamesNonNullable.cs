namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeBookAndReaderNamesNonNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Readers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Readers", "Name", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
