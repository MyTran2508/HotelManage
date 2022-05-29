using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Dich Vu
    [Table("service")]
    public class Service
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
       
        [Required]
        public string Name { get; set; }
       
        [Required]
        public float Price { get; set; }

    }
}
