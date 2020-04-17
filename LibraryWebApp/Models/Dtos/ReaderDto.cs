using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Dtos
{
    public class ReaderDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public ReaderDto()
        {
            Books = new List<Book>();
        }
    }
}