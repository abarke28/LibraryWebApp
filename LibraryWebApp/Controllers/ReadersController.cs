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
            var reader = DatabaseHelper.GetReaders(r => r.Id == id).First();
            return View(reader);
        }
        public IActionResult New()
        {
            // Summary
            //
            // Add new User

            var membershipTypes = DatabaseHelper.GetMembershipTypes();
            var newReaderVm = new NewReaderViewModel { MembershipTypes = membershipTypes, Reader = new Reader() };

            return View(newReaderVm);
        }
    }
}