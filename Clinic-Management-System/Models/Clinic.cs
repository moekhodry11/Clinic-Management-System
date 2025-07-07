using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class  Clinic
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Email { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();

        public virtual ICollection<Assistant> Assistants { get; set; } = new HashSet<Assistant>();
    }
}
