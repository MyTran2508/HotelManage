using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    [Table("list_use_services")]
    public class ListUseService
    {
        [Key, Column(Order = 0)]
        public string Id { get; set; }
        
        [Key, Column(Order = 1)]
        public string ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

        [Required]
        public string ServiceId { get; set; }
        public virtual Service Service { get; set; }


    }
}
