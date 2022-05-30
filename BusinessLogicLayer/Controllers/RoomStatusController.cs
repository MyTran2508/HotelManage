using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Entities;

namespace BusinessLogicLayer.Controllers
{
    public class RoomStatusController
    {
        // Make Room Status
        public RoomStatus GetRoomStatus(string Id, string Name)
        {
            RoomStatus roomStatus = new RoomStatus();
            roomStatus.Id = Id; 
            roomStatus.Name = Name; 
            return roomStatus;  
        }

        // Get All Room Status
        public List<RoomStatus> GetAllRoomsStatus()
        {
            try
            {
                using (var context = new Context())
                {
                    var roomsStatus = context.roomStatus.ToList();
                    return roomsStatus;
                }
            }
            catch
            {
                return null;
            }
        }
    
        // Create new Room Status
        public bool InsertRoomStatus(string Id, string Name)
        {
            try
            {
                using (var context = new Context())
                {
                    var roomSta = GetRoomStatus(Id, Name);
                    context.roomStatus.Add(roomSta);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
