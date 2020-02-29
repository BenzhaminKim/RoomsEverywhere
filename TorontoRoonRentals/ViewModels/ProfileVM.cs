using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorontoRoonRentals.Models;

namespace TorontoRoonRentals.ViewModels
{
    public class ProfileVM
    {
        public ProfileVM()
        {
            this.Reviews = new HashSet<Review>();
        }

        public string ProfileId { get; set; }
        public string PhoneNumber { get; set; }
        public string Introduction { get; set; }
        public string Name { get; set; }
        public string Languages { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }
    }
}
