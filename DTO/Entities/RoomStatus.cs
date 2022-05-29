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
        public string Id { get; set; }

        // Ten trang thai
        [Required]
        public string Name { get; set; }

    }
}
