using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class ReadersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var reader = new Reader() { Name = "Alex Barker", Id = id };
            return View(reader);
        }
    }
}