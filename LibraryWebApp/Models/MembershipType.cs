using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class MembershipType
    {
        public int UpfrontFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
        public int MembershipTypeId { get; set; }
    }
}
