﻿using System;
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
            dbContext.SaveChanges();
        }
        public static void UpdateReader(Reader reader)
        {
            // Summary
            //
            // Update supplied reader

            using var dbContext = new LibraryContext();
            var dbReader = dbContext.Readers.First(r => r.Id == reader.Id);

            dbReader.IsSubscribedToNewsletter = reader.IsSubscribedToNewsletter;
            dbReader.MembershipType = reader.MembershipType;
            dbReader.MembershipTypeId = reader.MembershipTypeId;
            dbReader.Name = reader.Name;

            dbContext.SaveChanges();
        }
        public static IEnumerable<Reader> GetReaders()
        {
            // Summary
            //
            // Get all Readers. Also fetch membershipTypes with Eager Loading

            using var dbContext = new LibraryContext();
            return dbContext.Readers.Include(r => r.MembershipType).ToList();
        }
        public static IEnumerable<Reader> GetReaders(Predicate<Reader> predicate)
        {
            // Summary
            //
            // Gets all readers as filtered by supplied predicate. Also fetch membershipTypes with Eager Loading

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
            dbContext.SaveChanges();
        }
        public static void UpdateBook(Book book)
        {
            // Summary
            //
            // Update supplied book

            using var dbContext = new LibraryContext();
            var dbBook = dbContext.Books.First(b => b.Id == book.Id);

            dbBook.AuthorFirstName = book.AuthorFirstName;
            dbBook.AuthorLastName = book.AuthorLastName;
            dbBook.Genre = book.Genre;
            dbBook.GenreId = book.GenreId;
            dbBook.PublishedYear = book.PublishedYear;
            dbBook.PublishedMonth = book.PublishedMonth;
            dbBook.Synopsis = book.Synopsis;
            dbBook.Title = book.Title;
            dbBook.NumInStock = book.NumInStock;

            dbContext.SaveChanges();
        }
        public static IEnumerable<Book> GetBooks()
        {
            // Summary
            //
            // Get all books

            using var dbContext = new LibraryContext();
            return dbContext.Books.Include(b => b.Genre).ToList();
        }
        public static IEnumerable<Book> GetBooks(Predicate<Book> predicate)
        {
            // Summary
            //
            // Gets all books as filtered by supplied predicate

            using var dbContext = new LibraryContext();

            return dbContext.Books.Include(b => b.Genre).Where(new Func<Book, bool>(predicate)).ToList();
        }

        public static IEnumerable<MembershipType> GetMembershipTypes()
        {
            // Summmary
            //
            // Get all MembershipTypes

            using var dbContext = new LibraryContext();
            return dbContext.MembershipTypes.ToList();
        }
        public static IEnumerable<Genre> GetGenres()
        {
            // Summary
            //
            // Return list of all genres

            using var dbContext = new LibraryContext();
            return dbContext.Genres.ToList();
        }
    }
}