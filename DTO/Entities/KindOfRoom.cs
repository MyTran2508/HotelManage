using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Loai Phong
    [Table("kind_of_rooms")]
    public class KindOfRoom
    {
        [Key]
        // Mã Loại Phòng
        public string Id { get; set; }
        
        // Tên Loại Phòng
        [Required]
        public string Name { get; set; }

        // Số Người Tối Đa
        public int Max { get; set; }

        // Đơn Giá
        public float Price { get; set; }

        // Colection navigation
       //public virtual List<Room> Rooms { get; set; }

    }
}
