using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.ViewModels
{
    public class LocationVM
    {
        [Key]
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public String ImagePath { get; set; }
        public decimal Price { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Type { get; set; }

    }
}
