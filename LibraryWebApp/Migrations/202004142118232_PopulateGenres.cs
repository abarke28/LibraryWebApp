namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Literary Fiction');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Thriller');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Self-Help');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Non-fiction');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Classic');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Short Stories');");
            Sql("INSERT INTO Genres (GenreTypeName) VALUES ('Comedy');");
        }
        
        public override void Down()
        {
        }
    }
}
