using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public static class DatabaseHelper
    {
        public const string CONNECTION_STRING = @"Data Source=DELLLAPTOP\ABSQL01;Initial Catalog=LibraryDb;Integrated Security=True";

        public static void AddReader(Reader reader)
        {
            // Summary
            //
            // Add supplied item to DB

            if (reader == null) throw new ArgumentNullException("Supplied Reader is null");
            if (reader.Name == null) throw new ArgumentException("Supplied Reader missing mandatory field: Name");

            using var dbContext = new LibraryContext();

            dbContext.Readers.Add(reader);
            dbContext.SaveChangesAsync();
        }
        public static IEnumerable<Reader> GetReaders()
        {
            // Summary
            //
            // Get all Readers

            using var dbContext = new LibraryContext();
            return dbContext.Readers.Include(r => r.MembershipType).ToList();
        }
        public static IEnumerable<Reader> GetReaders(Predicate<Reader> predicate)
        {
            // Summary
            //
            // Gets all readers as filtered by supplied predicate

            using var dbContext = new LibraryContext();

            return dbContext.Readers.Include(r => r.MembershipType).Where(new Func<Reader, bool>(predicate)).ToList();
        }

        public static void AddBook(Book book)
        {
            // Summary
            //
            // Add supplied book

            if (book == null) throw new ArgumentNullException("Supplied Book is null");
            if (String.IsNullOrEmpty(book.Title)) throw new ArgumentException("Supplied Book missing mandatory field: Title");

            using var dbContext = new LibraryContext();
            dbContext.Books.Add(book);
            dbContext.SaveChangesAsync();
        }
        public static IEnumerable<Book> GetBooks()
        {
            // Summary
            //
            // Get all books

            using var dbContext = new LibraryContext();
            return dbContext.Books.ToList();
        }
        public static IEnumerable<Book> GetBooks(Predicate<Book> predicate)
        {
            // Summary
            //
            // Gets all books as filtered by supplied predicate

            using var dbContext = new LibraryContext();

            return dbContext.Books.Where(new Func<Book, bool>(predicate)).ToList();
        }
    }
}