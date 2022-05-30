using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Entities;
using System.Data.Entity;

namespace BusinessLogicLayer.Controllers
{
    // Room Controller
    public class RoomController
    {
        // Create Room Instance
        private Room GetRoom(
            string Id,
            KindOfRoom kindOfRoom,
            RoomStatus roomStatus,
            string Name,
            string Description = ""
        )
        {
           var room = new Room();   
            room.Id = Id;
            room.Name = Name;
            room.Description = Description;
            room.KindOfRoom = kindOfRoom;
            room.RoomStatus = roomStatus;
            return room;
        }
    
        // Get All Rooms
        public List<Room> GetAllRooms(ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rooms = context.rooms.ToList();
                    foreach (var room in rooms)
                    {
                        var e = context.Entry(room);
                        e.Reference("KindOfRoom").Load();
                        e.Reference("RoomStatus").Load();
                    }
                    error = "Get All Rooms Success!!!";
                    return rooms;
                }
            }
            catch
            {
                error = "Get All Rooms Failure!!!";
                return null;
            }
        }
    
        // Insert Room
        public bool InsertRoom(
            ref string error,
            string Id, 
            KindOfRoom kindOfRoom, 
            RoomStatus roomStatus, 
            string Name, 
            string Description = "")
        {
            try
            {
                using (var context = new Context())
                {
                    // Create Room
                    //var room = GetRoom(Id, kindOfRoom, roomStatus, Name, Description);

                    var room = new Room
                    {
                        Id = Id,
                        Description = Description,
                        KindOfRoomId = kindOfRoom.Id,
                        RoomStatusId = roomStatus.Id,
                        Name = Name,
                    };
                    context.rooms.Add(room);
                    var e = context.Entry(room);
                    e.Reference("KindOfRoom");
                    e.Reference("RoomStatus");
                    context.SaveChanges();
                    error = "Add New Room Success!!!";
                    return true;
                }
            }
            catch (Exception ex)
            {
                //error = "Something Was Wrong When Add Room!!!";
                error = ex.Message;
                return false;
            }
        }
        
        // Update Room
        public bool UpdateRoom
        (
            ref string error,
            string Id,
            string kindOfRoomId,
            string roomStatusId,
            string Name,
            string Description = ""
        )
        {
            try
            {
                using(var context = new Context())
                {
                    // Find Room
                    var room = context.rooms.
                        Where(r => r.Id == Id).FirstOrDefault();

                  /*  var e = context.Entry(room);
                    e.State = System.Data.Entity.EntityState.Modified; */

                    // Update Room
                    if (room != null)
                    {
                        room.Name = Name;   
                        room.Description = Description; 
                        room.RoomStatusId = roomStatusId;
                        room.KindOfRoomId = kindOfRoomId;
                        context.SaveChanges();
                        error = "Room Has Updated!!!";
                        return true;
                    }
                    error = "Room Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Update Room!!!";
                return false;
            }
        }
        
        // Delete Room
        public bool RemoveRoom(ref string error, string Id)
        {
            try
            {
                using(var context = new Context())
                {
                    // Find Room
                    var room = context.rooms.
                        Where(r => r.Id != Id).FirstOrDefault();

                    // Remove If Room Exist
                    if(room != null)
                    {
                        context.rooms.Remove(room);
                        context.SaveChanges();
                        error = "Room Has Deleted!!!";
                        return false;
                    }
                    error = "Room Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Sonmething Was Wrong When Remove Room!!!";
                return false;
            }
        }
    
        // Get Room By StatusId
        public List<Room> GetRoomsByRoomStatusId(string roomStatusId, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rooms = context.rooms.
                        Where(r => r.RoomStatusId == roomStatusId).ToList();
                    foreach (var room in rooms)
                    {
                        var e = context.Entry(room);
                        e.Reference("KindOfRoom").Load();
                        e.Reference("RoomStatus").Load();
                    }
                    error = "Get All Rooms Success!!!";
                    return rooms;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Rooms!!!";
                return null;
            }
        }
    
    }
}
