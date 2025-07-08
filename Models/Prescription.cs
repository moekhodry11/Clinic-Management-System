using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int AppointmentId { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public string PatientPhoneNumber { get; set; }

        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Drug> Drugs { get; set; } = new HashSet<Drug>();
    }
}
