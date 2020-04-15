using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.ViewModels
{
    public class ReaderFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Reader Reader { get; set; }
    }
}
