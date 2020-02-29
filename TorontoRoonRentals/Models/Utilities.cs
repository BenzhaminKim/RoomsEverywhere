using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Utilities
    {
        public int UtilityId { get; set; }
        public int RoomId { get; set; }
        public bool HasHydro { get; set; }
        public bool HasHeat { get; set; }
        public bool HasAirconditioning { get; set; }
        public bool HasWater { get; set; }
        public bool HasWifi { get; set; }
        public bool HasTv { get; set; }

       // public Room? Room { get; set; }
    }
}
