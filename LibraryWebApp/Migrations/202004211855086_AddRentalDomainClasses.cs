namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalDomainClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_Id = c.Int(nullable: false),
                        Reader_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.Reader_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Reader_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Reader_Id", "dbo.Readers");
            DropForeignKey("dbo.Rentals", "Book_Id", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "Reader_Id" });
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
