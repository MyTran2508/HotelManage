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
    [Table("rom")]
    public class Room
    {
        [Key]
        public string Id { get; set; }
        
        // Ten phong
        [Required]
        public string Name { get; set; }

        // Mo ta
        public string Description { get; set; } 
    }
}
