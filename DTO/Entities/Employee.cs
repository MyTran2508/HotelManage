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
    [Table("employee")]
    public class Employee
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }
    }
}