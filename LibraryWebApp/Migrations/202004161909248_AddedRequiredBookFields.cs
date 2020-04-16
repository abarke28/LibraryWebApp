namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredBookFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            AlterColumn("dbo.Books", "AuthorLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "AuthorFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Synopsis", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            AlterColumn("dbo.Books", "Synopsis", c => c.String());
            AlterColumn("dbo.Books", "AuthorFirstName", c => c.String());
            AlterColumn("dbo.Books", "AuthorLastName", c => c.String());
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId");
        }
    }
}
