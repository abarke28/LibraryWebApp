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

        [Display(Name = "Reader (Full Name)"), Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type"), Required(ErrorMessage = "Membership Type is required")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Reader()
        {
            Books = new List<Book>();
        }
    }
}