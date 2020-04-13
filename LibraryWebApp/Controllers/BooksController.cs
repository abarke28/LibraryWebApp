using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (string.IsNullOrEmpty(sortBy)) sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public IActionResult Random()
        {
            Book book = new Book { Title = "Infinite Jest", Author = "Wallace, David Foster" };

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            return Content(@"id=" + id);
        }

        public IActionResult Detail()
        {
            return Content("Author: " + "Wallace, David Foster");
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