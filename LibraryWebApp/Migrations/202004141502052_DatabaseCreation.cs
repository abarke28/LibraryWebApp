namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorLastName = c.String(),
                        AuthorFirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReaderBooks",
                c => new
                    {
                        Reader_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reader_Id, t.Book_Id })
                .ForeignKey("dbo.Readers", t => t.Reader_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Reader_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.ReaderBooks", "Reader_Id", "dbo.Readers");
            DropIndex("dbo.ReaderBooks", new[] { "Book_Id" });
            DropIndex("dbo.ReaderBooks", new[] { "Reader_Id" });
            DropTable("dbo.ReaderBooks");
            DropTable("dbo.Readers");
            DropTable("dbo.Books");
        }
    }
}
