using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet("books")]
        public IActionResult Index()
        {
            // Summary
            //
            // Display all books

            var vm = new BooksViewModel
            {
                Books = DatabaseHelper.GetBooks().ToList()
            };

            return View(vm);
        }

        [HttpGet("books/detail/{id}")]
        public IActionResult Detail(int id)
        {
            var book = DatabaseHelper.GetBooks(b => b.Id == id).First();

            return View(book);
        }

        public IActionResult New()
        {
            // Summary
            //
            // Add new Book

            var genres = DatabaseHelper.GetGenres();
            var vm = new BookFormViewModel { Genres = genres, Book = new Book() };
            
            return View("BookForm", vm);
        }

        public IActionResult Edit(int id)
        {
            // Summary
            //
            // Edit supplied book

            var book = DatabaseHelper.GetBooks(b => b.Id == id).FirstOrDefault();

            if (book == null) return NotFound();

            var vm = new BookFormViewModel 
            { 
                Book = book, 
                Genres = DatabaseHelper.GetGenres() 
            };

            return View("BookForm", vm);
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            // Summary
            //
            // If new - save, else - update

            if (book.Id == 0) DatabaseHelper.AddBook(book);
            else DatabaseHelper.UpdateBook(book);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet("books/authors/{lastName}/{firstName}")]
        public IActionResult Authors(string lastName, string firstName)
        {
            return Content("Author: " + lastName + ", " + firstName);
        }

        [HttpGet("books/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}})}")]
        public IActionResult Published(int year, int month)
        {
            return Content(String.Format("{0}/{1}", year, month));
        }
    }
}