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

        [Display(Name = "Author (Last Name)")]
        public string AuthorLastName { get; set; }

        [Display(Name = "Author (First Name)")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Publication Year")]
        public int PublishedYear { get; set; }
        
        [Display(Name = "Publication Month"), Range(1,12)]
        public int PublishedMonth { get; set; }
        
        public string Synopsis { get; set; }
        
        public Genre Genre { get; set; }
        
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }
        
        public int NumInStock { get; set; }

        public virtual ICollection<Reader> Readers { get; set; }

        public Book()
        {
            Readers = new List<Reader>();
        }
    }
}
