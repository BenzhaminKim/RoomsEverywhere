using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Review = new HashSet<Review>();
        }

        public string ProfileId { get; set; }
        public string PhoneNumber { get; set; }
        public string Introduction { get; set; }
        public string Name { get; set; }
        public string Languages { get; set; }

        public AspNetUsers ProfileNavigation { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
