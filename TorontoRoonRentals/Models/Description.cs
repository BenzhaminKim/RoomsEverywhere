using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Description
    {
        public int DescriptionId { get; set; }
        public int RoomId { get; set; }
        public string MainDescription { get; set; }
        public string Space { get; set; }
        public string Availability { get; set; }
        public string Neighborhood { get; set; }
        public string Transportation { get; set; }

        public Room Room { get; set; }
    }
}
