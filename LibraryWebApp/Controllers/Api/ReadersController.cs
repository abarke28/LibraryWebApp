using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class ReadersController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly MapperConfiguration _mappingConfig;
        protected readonly IMapper _mapper;

        public ReadersController()
        {
            _context = new LibraryContext();
            _mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _mappingConfig.CreateMapper();
        }

        // GET api/readers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ReaderDto>> GetReaders(string query = null)
        {
            // Summary
            //
            // Return all readers, filterable by a query

            var readersQuery = _context.Readers
                .Include(r => r.MembershipType);

            if (!String.IsNullOrEmpty(query))
                readersQuery = readersQuery.Where(r => r.Name.Contains(query));

            var readersDtos = readersQuery
                .ToList()
                .Select(_mapper.Map<Reader, ReaderDto>);

            return Ok(readersDtos);
        }

        // GET api/readers/{id}
        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ReaderDto> GetReader(int id)
        {
            // Summary
            //
            // Return Reader matching supplied Id

            var reader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (reader == null) return BadRequest();

            return Ok(_mapper.Map<ReaderDto>(reader));
        }

        // POST api/readers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateReader(ReaderDto readerDto)
        {
            // Summary
            //
            // Post/create Reader

            if (!ModelState.IsValid) return BadRequest();

            var reader = _mapper.Map<Reader>(readerDto);

            _context.Readers.Add(reader);
            _context.SaveChanges();

            return Created((Request.Path.ToString() + @"/" + reader.Id), reader);
        }

        // PUT api/readers/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateReader(int id, ReaderDto readerDto)
        {
            // Summary
            //
            // Update supplied customer

            if (!ModelState.IsValid) return BadRequest();

            var dbReader = _context.Readers.FirstOrDefault(r => r.Id == id);

            if (dbReader == null) return BadRequest();

            _mapper.Map<ReaderDto, Reader>(readerDto, dbReader);

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