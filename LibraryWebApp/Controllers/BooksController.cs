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

        public IActionResult Random()
        {
            var book = new Book() { Title = "Infinite Jest", AuthorLastName = "Wallace", AuthorFirstName="David Foster" };

            var vm = new RandomBookViewModel()
            {
                Book = book,
                Readers = new List<Reader>()
                {
                    new Reader() {Name = "Alex Barker", Id=1},
                    new Reader() {Name = "Nicole Foster", Id=2}
                }
            };

            return View(vm);
        }

        [HttpGet("books/detail/{id}")]
        public IActionResult Detail(int id)
        {
            var book = new Book() { AuthorLastName = "x", Title = "y", Id = id };

            return View(book);
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