using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base(DatabaseHelper.CONNECTION_STRING)
        {
            // Pass Connection string from appsettings.json
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}