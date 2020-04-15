using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
