
namespace Clinic.Domain.Entities;
    public class Patient : User
    {
        // Relationship with clinic
        public int? ClinicId { get; set; }
        public MyClinic? MyClinic { get; set; }
        
        // Navigation
        // Prescriptions in Appointment or make a direct relationship?
        // public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public ICollection<ChronicDisease> ChronicDiseases { get; set; } = new HashSet<ChronicDisease>();
    }

