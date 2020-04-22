using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly MapperConfiguration _mappingConfig;
        protected readonly IMapper _mapper;

        public RentalsController()
        {
            _context = new LibraryContext();
            _mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _mappingConfig.CreateMapper();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ProcessRental(RentalDto rentalDto)
        {
            // Summary
            //
            // Executes rental transaction for supplied Id

            if (!ModelState.IsValid) return BadRequest("Invalid query");

            var reader = _context.Readers.FirstOrDefault(r => r.Id == rentalDto.ReaderId);

            // Reader not found
            if (reader == null) return BadRequest();

            var books = _context.Books.Where(b => rentalDto.BookIds.Contains(b.Id));

            // No Books found
            if (books.Count() == 0) return BadRequest("No books found");

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

                    // Take one from stock of book
                    book.NumInStock -= 1;

                    break;
                }
                // Book not in stock, add to unavailable list to return to user

                return BadRequest(String.Format("Book with id {0} not available", book.Id.ToString()));
            }

            //_context.SaveChanges();

            return Ok();
        }
    }
}