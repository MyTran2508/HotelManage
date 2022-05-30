using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Entities
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerId { get; set; } // CMND

        public string Phonenumber { get; set; }

        public string Address { get; set; }
    }
}
