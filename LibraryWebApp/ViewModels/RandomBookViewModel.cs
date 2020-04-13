using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Reader> Readers { get; set; }
    }
}
