using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class RoomImages
    {
        public int RoomImageId { get; set; }
        public int RoomId { get; set; }
        public string ImagePath { get; set; }

        public Room Room { get; set; }
    }
}
