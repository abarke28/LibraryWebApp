namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockNumToBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumInStock");
        }
    }
}
