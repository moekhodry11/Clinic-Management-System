using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person
    {
        [Key]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public string Gender { get; set; }
        public string? Email { get; set; }
     
        public string? Address { get; set; }

        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
