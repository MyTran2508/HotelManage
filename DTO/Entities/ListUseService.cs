using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    [Table("list_use_service")]
    public class ListUseService
    {
        [Key]
        public string Id { get; set; }
        
        public string ReservationId { get; set; }

        public string ServiceId { get; set; }


    }
}
