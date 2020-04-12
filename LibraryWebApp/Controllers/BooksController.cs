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
        public IActionResult Random()
        {
            Book book = new Book { Title = "Infinite Jest", Author = "Wallace, David Foster" };

            return View(book);
        }
    }
}