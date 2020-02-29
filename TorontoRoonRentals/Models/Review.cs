using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string ProfileId { get; set; }
        public string Comments { get; set; }
        public DateTime Reviewdate { get; set; }

        public Profile Profile { get; set; }
    }
}
