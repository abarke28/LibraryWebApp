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
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly MapperConfiguration _mappingConfig;
        protected readonly IMapper _mapper;

        public BooksController()
        {
            _context = new LibraryContext();
            _mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _mappingConfig.CreateMapper();
        }

        // GET api/books
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            // Summary
            //
            // Return all books

            return Ok(_context.Books.ToList().Select(_mapper.Map<Book, BookDto>));
        }

        // GET api/books/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDto> GetBook(int id)
        {
            // Summary
            //
            // Return Book matching supplied Id

            var Book = _context.Books.FirstOrDefault(r => r.Id == id);

            if (Book == null) return BadRequest();

            return Ok(_mapper.Map<BookDto>(Book));
        }

        // POST api/books
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateBook(BookDto BookDto)
        {
            // Summary
            //
            // Post/create Book

            if (!ModelState.IsValid) return BadRequest();

            var Book = _mapper.Map<Book>(BookDto);

            _context.Books.Add(Book);
            _context.SaveChanges();

            return Created((Request.Path.ToString() + @"/" + Book.Id), Book);
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateBook(int id, BookDto BookDto)
        {
            // Summary
            //
            // Update supplied customer

            if (!ModelState.IsValid) return BadRequest();

            var dbBook = _context.Books.FirstOrDefault(r => r.Id == id);

            if (dbBook == null) return BadRequest();

            _mapper.Map(BookDto, dbBook);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/books/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteBook(int id)
        {
            // Summary
            //
            // Delete supplied Custoemr

            var Book = _context.Books.FirstOrDefault(r => r.Id == id);

            if (Book == null) return BadRequest();

            _context.Books.Remove(Book);
            _context.SaveChanges();

            return Ok();
        }

        ~BooksController()
        {
            _context.Dispose();
        }
    }
}