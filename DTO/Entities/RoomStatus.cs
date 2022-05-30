using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{

    // Trang Thai Phong
    [Table("rom_status")]
    public class RoomStatus
    {
        [Key]
        // Trạng Thái Phòng
        public string Id { get; set; }

        // Tên Trạng Thái Phòng
        [Required]
        public string Name { get; set; }

        //public virtual List<Room> Rooms { get; set; }
    }
}
