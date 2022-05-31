using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Entities;

namespace BusinessLogicLayer.Controllers
{

    


    // Room Status Controller
    public class KindOfRoomController
    {

        // Create Kind Of Room
        public KindOfRoom GetKindOfRoom(string Id, String Name, int Max, float Price)
        {
            KindOfRoom k = new KindOfRoom();
            k.Id = Id; 
            k.Name = Name;
            k.Max = Max;
            k.Price = Price;
            return k;
        }

        // Get All Kind Of Rooms
        public List<KindOfRoom> GetAllKindOfRooms()
        {
            try
            {
                using (var context = new Context())
                {
                    var kindOfRooms = context.kindOfRooms.ToList();
                  
                    return kindOfRooms;
                }
            }
            catch
            {
                return null;
            }
        }
   
        // Insert New Kind Of Rom 
        public bool InsertKindOfRooms(string Id, string Name, int Max, float Price)
        {
            try
            {
                using (var context = new Context())
                {
                    var k = GetKindOfRoom(Id, Name, Max, Price);
                    context.kindOfRooms.Add(k);
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
