using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities;
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public PrescriptionStatus PrescriptionStatus { get; set; }
        public string? Diagnosis { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        // Navigation
        public required Appointment Appointment { get; set; }
        public required Doctor Doctor { get; set; }
        public required Patient Patient { get; set; }
        public List<PrescriptionItem>? Items { get; set; }
        public List<MedicalReport>? MedicalReport { get; set; }

    }

