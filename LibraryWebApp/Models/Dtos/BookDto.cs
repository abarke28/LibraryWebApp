﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorLastName { get; set; }

        public string AuthorFirstName { get; set; }

        public int PublishedYear { get; set; }

        public int PublishedMonth { get; set; }

        public string Synopsis { get; set; }

        public int? GenreId { get; set; }

        public virtual ICollection<Reader> Readers { get; set; }

        public BookDto()
        {
            Readers = new List<Reader>();
        }
    }
}
