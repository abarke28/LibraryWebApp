using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Dtos
{
    public class RentalDto
    {
        public int ReaderId { get; set; }
        public List<int> BookIds { get; set; }
    }
}