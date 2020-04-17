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
        ~ReadersController()
        {
            _context.Dispose();
        }

        [HttpGet] // GET api/readers
        public IEnumerable<Reader> GetReaders()
        {
            // Summary
            //
            // Return all readers

            return _context.Readers.Include(r => r.MembershipType).ToList();
        }

        [HttpGet("{id}")] // GET api/readers/{id}
        public Reader GetReader(int id)
        {
            // Summary
            //
            // Return Reader matching supplied Id

            var reader = _context.Readers.Include(r => r.MembershipType).FirstOrDefault(r => r.Id == id);

            if (reader == null) throw new Exception("Not found");

            return reader;
        }

        [HttpPost] // POST api/readers
        public Reader CreateReader(Reader reader)
        {
            // Summary
            //
            // Post/create Reader

            if (!ModelState.IsValid) throw new Exception("Bad Request");

            _context.Readers.Add(reader);
            _context.SaveChanges();

            return reader;
        }

        [HttpPut("{id}")] // PUT api/readers/{id}
        public void UpdateCustomer(int id, Reader reader)
        {
            // Summary
            //
            // Update supplied customer

            if (!ModelState.IsValid) throw new Exception("Bad Request");

            var dbReader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (dbReader == null) throw new Exception("Not Found");

            dbReader.Name = reader.Name;
            dbReader.IsSubscribedToNewsletter = reader.IsSubscribedToNewsletter;
            dbReader.MembershipTypeId = reader.MembershipTypeId;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")] // DELETE api/readers/{id}
        public void DeleteCustomer(int id)
        {
            // Summary
            //
            // Delete supplied Custoemr

            var reader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (reader == null) throw new Exception("Not Found");

            _context.Readers.Remove(reader);
            _context.SaveChanges();
        }
    }
}