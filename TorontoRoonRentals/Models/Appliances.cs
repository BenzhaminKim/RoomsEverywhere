using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Appliances
    {
        public int ApplianceId { get; set; }
        public int RoomId { get; set; }
        public bool HasLanduary { get; set; }
        public bool HasDryer { get; set; }
        public bool HasDishwasher { get; set; }
        public bool HasFridge { get; set; }
        public bool HasMicrowave { get; set; }

        public Room Room { get; set; }
    }
}
