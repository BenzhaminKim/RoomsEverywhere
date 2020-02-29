using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TorontoRoonRentals.Data;
using TorontoRoonRentals.Models;
using TorontoRoonRentals.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using TorontoRoonRentals.Common;

namespace TorontoRoonRentals.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        TorontoRoomRentalsContext db = new TorontoRoomRentalsContext();
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PostRoom()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<IActionResult> PostRoom(RoomVM roomVM)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    AzureConnection azureConnection = new AzureConnection();

                    roomVM.Room.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    roomVM.Room.CreatedDate = DateTime.Now;

                    db.Room.Add(roomVM.Room);
                    await db.SaveChangesAsync();

                    roomVM.Utilities.RoomId = roomVM.Room.RoomId;
                    roomVM.Appliances.RoomId = roomVM.Room.RoomId;
                    roomVM.Description.RoomId = roomVM.Room.RoomId;

                    db.Utilities.Add(roomVM.Utilities);
                    db.Appliances.Add(roomVM.Appliances);
                    db.Description.Add(roomVM.Description);


                    foreach (var image in roomVM.Images)
                    {
                        if (image.Length > 0)
                        {
                            RoomImages roomImage = new RoomImages();

                            string url = "https://sqlvamstj45g4qye7y.blob.core.windows.net/images";
                            string extension = Path.GetExtension(image.FileName);
                            string year = DateTime.Now.Year.ToString();
                            string month = DateTime.Now.Month.ToString();
                            string day = DateTime.Now.Day.ToString();
                            string nowTime = DateTime.Now.ToString("yymmssffff");

                            string path = $@"{year}\{month}\{day}\{roomVM.Room.RoomId}\";
                            string fileName = User.FindFirst(ClaimTypes.NameIdentifier).Value + nowTime + extension;
                            string imagePathAndFileName = path + fileName;
                           
                            using(var memoryStream = new MemoryStream())
                            {
                                await image.CopyToAsync(memoryStream);
                                memoryStream.Position = 0;
                                await azureConnection.UploadImageMemoryStream(imagePathAndFileName, memoryStream);
                            }

                            var imageUrlPath = $@"{url}/{year}/{month}/{day}/{roomVM.Room.RoomId}/{fileName}";
                            roomImage.RoomId = roomVM.Room.RoomId;
                            roomImage.ImagePath = imageUrlPath;
                            roomVM.RoomImages.Add(roomImage);
                        }
                    }

                    await db.RoomImages.AddRangeAsync(roomVM.RoomImages);
                    await db.SaveChangesAsync();

                    return RedirectToAction("RoomDetail", new { id = roomVM.Room.RoomId });
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

 
        [HttpGet]
     public async Task<IActionResult> RoomEdit(int? id)
        {
            try
            {
                if (id == null)
                    return StatusCode(500);
                var room = db.Room.Find(id);

                if (room == null)
                    return StatusCode(404);

                if (room.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    var utility = db.Utilities.Where(u => u.RoomId == room.RoomId).FirstOrDefault();
                    var appliance = db.Appliances.Where(a => a.RoomId == room.RoomId).FirstOrDefault();
                    var description = db.Description.Where(d => d.RoomId == room.RoomId).FirstOrDefault();
                    RoomVM roomVM = new RoomVM
                    {
                        Room = room,
                        Utilities = utility,
                        Appliances = appliance,
                        Description = description
                    };
                    TempData["roomID"] = room.RoomId;
                    return View(roomVM);
                }
                return RedirectToAction("Index");
            }
            catch (Exception )
            {

                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> RoomEdit(RoomVM roomVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int roomId = (int)TempData["roomID"];
                    Room room = await db.Room.FindAsync(roomId);

                    if (room == null)
                        return StatusCode(404);

                    if (room.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    {
                        Utilities utility = db.Utilities.Where(u => u.RoomId == room.RoomId).FirstOrDefault();
                        Appliances appliance = db.Appliances.Where(a => a.RoomId == room.RoomId).FirstOrDefault();
                        Description description = db.Description.Where(d => d.RoomId == room.RoomId).FirstOrDefault();

                        roomVM.Room.RoomId = room.RoomId;
                        roomVM.Room.UserId = room.UserId;
                        roomVM.Room.CreatedDate = DateTime.Now;
                        roomVM.Utilities.RoomId = utility.RoomId;
                        roomVM.Utilities.UtilityId = utility.UtilityId;
                        roomVM.Appliances.RoomId = appliance.RoomId;
                        roomVM.Appliances.ApplianceId = appliance.ApplianceId;
                        roomVM.Description.RoomId = description.RoomId;
                        roomVM.Description.DescriptionId = description.DescriptionId;

                        db.Entry(room).CurrentValues.SetValues(roomVM.Room);
                        db.Entry(utility).CurrentValues.SetValues(roomVM.Utilities);
                        db.Entry(appliance).CurrentValues.SetValues(roomVM.Appliances);
                        db.Entry(description).CurrentValues.SetValues(roomVM.Description);

                        await db.SaveChangesAsync();
                        return RedirectToAction("RoomDetail", new { id = roomVM.Room.RoomId });
                    }
                }
                catch (Exception )
                {
                    return View();
                }
            }
            return View();
      
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RoomDetail(int? id)
        {
            if (id == null)
                return StatusCode(500);
            var room = await db.Room.FindAsync(id);
            var utility = db.Utilities.Where(u => u.RoomId == room.RoomId).FirstOrDefault();
            var appliance = db.Appliances.Where(a => a.RoomId == room.RoomId).FirstOrDefault();
            var description = db.Description.Where(d => d.RoomId == room.RoomId).FirstOrDefault();
            var roomImages = db.RoomImages.Where(i => i.RoomId == room.RoomId);
            if (room == null)
                return StatusCode(404);

            RoomVM roomVM = new RoomVM
            {
                Room = room,
                Utilities = utility,
                Appliances = appliance,
                Description = description
            };
            foreach (var image in roomImages)
            {
                roomVM.RoomImages.Add(image);
            }
            TempData["lat"] = room.Lat;
            TempData["lng"] = room.Lng;
            return View(roomVM);

        }

        [AllowAnonymous]
        public IActionResult RoomRental()
        {
            return View();
        }
    }
}