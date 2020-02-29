using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class AspNetUserTokens
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public AspNetUsers User { get; set; }
    }
}
