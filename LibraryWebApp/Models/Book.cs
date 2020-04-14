using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public virtual ICollection<Reader> Readers { get; set; }

        public Book()
        {
            Readers = new List<Reader>();
        }
    }
}
