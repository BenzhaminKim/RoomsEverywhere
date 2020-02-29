using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorontoRoonRentals.Models;
using TorontoRoonRentals.ViewModels;

namespace TorontoRoonRentals.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        TorontoRoomRentalsContext db = new TorontoRoomRentalsContext();

        List<LocationVM> locations = new List<LocationVM>();
        public  IEnumerable<LocationVM> Get()
        {
            var rooms = db.Room.ToList();

            foreach (var room in rooms)
            {
                //var roomImage = db.Rooms.Find(room.roomId).RoomImages.Where(image => image.roomId == room.roomId).First();

                if (db.RoomImages.Any(r => r.RoomId == room.RoomId))
                {
                    var roomImage = db.RoomImages.Where(image => image.RoomId == room.RoomId).First();
                    locations.Add(
                    new LocationVM()
                    {
                        RoomId = room.RoomId,
                        UserId = room.UserId,
                        Price = room.Price,
                        Lat = room.Lat,
                        Lng = room.Lng,
                        Title = room.Title,
                        Type = room.Type.GetValueOrDefault(1),
                        ImagePath = roomImage.ImagePath
                    }
                    );

                }
            }

            return locations;
        }
    }
}