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
    [Table("employees")]
    public class Employee
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}