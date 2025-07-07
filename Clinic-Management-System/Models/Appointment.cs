using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientPhoneNumber { get; set; }
        public double Cost { get; set; }

        public bool? Status { get; set; } // true for completed, null for pending, false for cancelled
       
        public DateTime AppointmentDate { get; set; }
        public string Summary { get; set; }
        public int ClinicId { get; set; }
        public string AssistantPhoneNumber { get; set; }
        public string DoctorPhoneNumber { get; set; }

        public Clinic Clinic { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Assistant Assistant { get; set; }
    }
}
