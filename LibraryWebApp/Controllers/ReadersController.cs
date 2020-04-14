using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class ReadersController : Controller
    {
        public IActionResult Index()
        {
            // Summary
            //
            // Display all readers

            var vm = new ReadersViewModel()
            {
                Readers = DatabaseHelper.GetReaders().ToList()
            };

            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var reader = new Reader() { Name = "Alex Barker", Id = id };
            return View(reader);
        }
    }
}