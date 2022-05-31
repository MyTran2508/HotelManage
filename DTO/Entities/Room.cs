using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Phong
    [Table("rooms")]
    public class Room
    {
        [Key]
        // Mã Phòng
        public string Id { get; set; }
        
        [Required]
        // Tên Phòng
        public string Name { get; set; }

        // Mô Tả Phòng
        public string Description { get; set; }




        // Foreign Key
        [Required]
        public string KindOfRoomId { get; set; }
        public virtual KindOfRoom KindOfRoom { get; set; }

        [Required]
        public string RoomStatusId { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }

    }
}
