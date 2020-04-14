using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Reader
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Reader()
        {
            Books = new List<Book>();
        }
    }
}