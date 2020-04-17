using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReadersController()
        {
            _context = new LibraryContext();
        }

        // GET api/readers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Reader> GetReaders()
        {
            // Summary
            //
            // Return all readers

            return _context.Readers.Include(r => r.MembershipType).ToList();
        }

        // GET api/readers/{id}
        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reader> GetReader(int id)
        {
            // Summary
            //
            // Return Reader matching supplied Id

            var reader = _context.Readers.Include(r => r.MembershipType).FirstOrDefault(r => r.Id == id);

            if (reader == null) return BadRequest();

            return Ok(reader);
        }

        // POST api/readers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reader> CreateReader(Reader reader)
        {
            // Summary
            //
            // Post/create Reader

            if (!ModelState.IsValid) return BadRequest();

            _context.Readers.Add(reader);
            _context.SaveChanges();

            return Ok(_context.Readers.Include(r => r.MembershipType).First(r => r.Name == reader.Name));
        }

        // PUT api/readers/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateReader(int id, Reader reader)
        {
            // Summary
            //
            // Update supplied customer

            if (!ModelState.IsValid) return BadRequest();

            var dbReader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (dbReader == null) return BadRequest();

            dbReader.Name = reader.Name;
            dbReader.IsSubscribedToNewsletter = reader.IsSubscribedToNewsletter;
            dbReader.MembershipTypeId = reader.MembershipTypeId;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/readers/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteReader(int id)
        {
            // Summary
            //
            // Delete supplied Custoemr

            var reader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (reader == null) return BadRequest();

            _context.Readers.Remove(reader);
            _context.SaveChanges();

            return Ok();
        }

        ~ReadersController()
        {
            _context.Dispose();
        }
    }
}