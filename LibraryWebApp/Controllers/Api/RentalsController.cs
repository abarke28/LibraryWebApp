using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly LibraryContext _context;

        RentalsController()
        {
            _context = new LibraryContext();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ProcessRental(RentalDto rentalDto)
        {
            // Summary
            //
            // Executes rental transaction for supplied Id

            var reader = _context.Readers.FirstOrDefault(r => r.Id == rentalDto.ReaderId);

            // Reader not found
            if (reader == null) return BadRequest();

            var books = _context.Books.Where(b => rentalDto.BookIds.Contains(b.Id));

            // No Books found
            if (books == null) return BadRequest();

            var unavailable = new List<Book>();

            foreach (Book book in books)
            {
                if (book == null) break;

                // Book is in stock, add rental
                if (book.NumInStock > 0)
                {
                    // Book is in stock, add rental
                    _context.Rentals.Add(new Rental()
                    {
                        Reader = reader,
                        Book = book,
                        DateRented = DateTime.Today
                    });
                    break;
                }
                // Book not in stock, add to unavailable list to return to user
                else
                {
                    unavailable.Add(book);
                }
            }

            _context.SaveChanges();

            // No rentals were unavailable
            if (unavailable.Count == 0) return Ok();

            // Some rentals were unavailable
            return Ok(unavailable);
        }
    }
}