using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO.Entities;
using System.Diagnostics;

namespace DTO
{
    // Init context
    public class Context : DbContext
    {
        public DbSet<Service> services { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<KindOfRoom> kindOfRooms { get; set; }
        public DbSet<RoomStatus> roomStatus { get; set; }

        // Constructor
        public Context() : base("name=hoteldata") 
        { 
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            
            // Show SQL
            Database.Log = sql => Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Employee>().
                HasIndex(e => e.Username).IsUnique();*/
        }

       
    }
}
