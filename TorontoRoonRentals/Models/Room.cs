using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoRoonRentals.Models
{
    public partial class Room
    {
        public Room()
        {
            Appliances = new HashSet<Appliances>();
            Description = new HashSet<Description>();
            RoomImages = new HashSet<RoomImages>();
            Utilities = new HashSet<Utilities>();
        }

        public int RoomId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        [DataType(DataType.Date)]
        public DateTime Moveindate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Bathrooms { get; set; }
        public bool IsParking { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool IsSmoking { get; set; }
        public int? Type { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<Appliances> Appliances { get; set; }
        public ICollection<Description> Description { get; set; }
        public ICollection<RoomImages> RoomImages { get; set; }
        public ICollection<Utilities> Utilities { get; set; }
    }
}
