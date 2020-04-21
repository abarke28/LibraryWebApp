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

            var book = _context.Books.FirstOrDefault(b => b.Id == rentalDto.ReaderId);

            // If Id not valid
            if (book == null) return BadRequest();

            // If no copies available
            if (book.NumInStock < 1) return BadRequest();

            // TODO: Implementation Logic

            return Ok();
        }
    }
}