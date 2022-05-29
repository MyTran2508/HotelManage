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
    [Table("kind_of_room")]
    public class KindOfRoom
    {
        [Key]
        public int Id { get; set; }
        
        // Ten loai phong
        [Required]
        public string Name { get; set; }

        // So nguoi toi da
        public int Max { get; set; }

        // Don gia
        public float Price { get; set; }

    }
}
