using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public int PublishedYear { get; set; }
        public int PublishedMonth { get; set; }
        public Genre Genre { get; set; }
        public int? GenreId { get; set; }

        public virtual ICollection<Reader> Readers { get; set; }

        public Book()
        {
            Readers = new List<Reader>();
        }
    }
}
