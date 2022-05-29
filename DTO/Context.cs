using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO.Entities;

namespace DTO
{
    // Init context
    public class Context : DbContext
    {
        // Constructor
        public Context() : base("name=hoteldata") { }

        // Khai bao cac bang
       /* public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<RoomStatus> romStatus { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<KindOfRoom> kindOfRooms { get; set; }
        public DbSet<Reservation> reservations { get; set; }*/

        public DbSet<Service> services { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
