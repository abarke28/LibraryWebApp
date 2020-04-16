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
        [HttpGet("readers")]
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

        [HttpGet("readers/detail/{id}")]
        public IActionResult Detail(int id)
        {
            var reader = DatabaseHelper.GetReaders(r => r.Id == id).First();
            return View(reader);
        }

        [HttpGet("readers/new")]
        public IActionResult New()
        {
            // Summary
            //
            // Add new User

            var membershipTypes = DatabaseHelper.GetMembershipTypes();
            var newReaderVm = new ReaderFormViewModel { MembershipTypes = membershipTypes, Reader = new Reader() };

            return View("ReaderForm", newReaderVm);
        }

        [HttpGet("readers/edit/{id}")]
        public IActionResult Edit(int id)
        {
            // Summary
            //
            // Load form with book specified by supplied id

            var reader = DatabaseHelper.GetReaders(r => r.Id == id).SingleOrDefault();

            if (reader == null) return NotFound();

            var vm = new ReaderFormViewModel()
            {
                Reader = reader,
                MembershipTypes = DatabaseHelper.GetMembershipTypes()
            };

            return View("ReaderForm", vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Save(Reader reader)
        {
            // Summary
            //
            // Check if Reader exists. If not -add, else - update

            if (!ModelState.IsValid)
            {
                var vm = new ReaderFormViewModel
                {
                    Reader = reader,
                    MembershipTypes = DatabaseHelper.GetMembershipTypes()
                };

                return View("ReaderForm", vm);
            }

            if (reader.Id == 0) DatabaseHelper.AddReader(reader);
            else DatabaseHelper.UpdateReader(reader);

            return RedirectToAction("Index", "Readers");
        }
    }
}