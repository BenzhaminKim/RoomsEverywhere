using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorontoRoonRentals.Models;

namespace TorontoRoonRentals.ViewModels
{
    public class RoomVM
    {
        public RoomVM()
        {
            RoomImages = new List<RoomImages>();
        }
        public Room Room { get; set; }
        public Utilities Utilities { get; set; }
        public Appliances Appliances { get; set; }
        public Description Description { get; set; }
        public virtual List<RoomImages> RoomImages { get; set; }    

        public IFormFile[] Images { get; set; }
    }
}

