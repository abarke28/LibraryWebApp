using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryWebApp.Models;
using LibraryWebApp.ViewModels;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Page Reached at " + DateTime.Now);
            return View();
        }

        public IActionResult Books()
        {
            var books = new List<Book>()
            {
                new Book(){Title = "Infinite Jest", Author = "Wallace, David Foster"},
                new Book(){Title = "Godel, Escher, Bach", Author = "Hofstader, Douglas"}
            };

            var booksVm = new BooksViewModel() { Books = books };

            return View("Books", booksVm);
        }

        public IActionResult Readers()
        {
            var readers = new List<Reader>()
            {
                new Reader(){Name = "Alex Barker"},
                new Reader(){Name = "Nicole Foster"},
                new Reader(){Name = "Euler"},
                new Reader(){Name = "Cauchy"}
            };

            var readersVm = new ReadersViewModel() { Readers = readers };

            return View("Readers", readersVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
