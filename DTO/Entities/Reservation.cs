using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Thue phong
    [Table("reservations")]
    public class Reservation
    {
        [Key]
        public string Id { get; set; }

        // Ngay Thue
        [Required]
        public DateTime DateIn { get; set; }
        
        // Ngay Tra
        [Required]
        public DateTime DateOut { get; set; }

        // Trang Thai
        [Required]
        public string Status { get; set; }

        // Foreign Key
        [Required]
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  

        [Required]
        public string RoomId { get; set; }
        public virtual Room Room { get; set; }  
    }
}
