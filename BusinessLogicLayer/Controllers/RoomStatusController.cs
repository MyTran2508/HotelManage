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
        public RoomStatus CreateRoomStatus(string Id, string Name)
        {
            return new RoomStatus
            {
                Id = Id,
                Name = Name
            };
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
    
        // Insert Room Status
        public bool InsertRoomStatus(string Id, string Name, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var roomSta = CreateRoomStatus(Id, Name);
                    context.roomStatus.Add(roomSta);
                    context.SaveChanges();
                    error = "Room Status Has Created!!!";
                    return true;
                }
            }
            catch
            {
                error = "Something Was Wrong When Add Room Status!!!";
                return false;
            }
        }
        
        // Update Room Status
        public bool UpdateRoomStatusById(string Id, string NewName, ref string error)
        {
            try
            {
                using(var context = new Context())
                {
                    var rs = context.roomStatus.
                        Where(r => r.Id == Id).FirstOrDefault();
                    if (rs != null)
                    {
                        rs.Name = NewName;
                        context.SaveChanges();
                        error = "Room Status Has Updated!!!";
                        return true;
                    }
                    error = "Room Status Is Not Exist!!!";
                    return false;

                }
            }
            catch
            {
                error = "Something Was Wrong When Update Room Status!!!";
                return false;
            }
        }

        // Delete Room Status
        public bool RemoveRoomStatusById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rs = context.roomStatus.
                        Where(r => r.Id == Id).FirstOrDefault();
                    if (rs != null)
                    {
                       context.roomStatus.Remove(rs);
                        context.SaveChanges();
                        error = "Room Status Has Deleted!!!";
                        return true;
                    }
                    error = "Room Status Is Not Exist!!!";
                    return false;

                }
            }
            catch
            {
                error = "Something Was Wrong When Delete Room Status!!!";
                return false;
            }
        }
    
        // Get Room Status By Id
        public RoomStatus GetRoomStatusById(string Id)
        {
            try
            {
                using(var context = new Context())
                {
                    var rs = context.roomStatus.
                        Where(r => r.Id==Id).FirstOrDefault();
                    return rs;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
