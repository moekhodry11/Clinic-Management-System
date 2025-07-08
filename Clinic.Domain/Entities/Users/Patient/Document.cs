namespace Clinic.Domain.Entities;
    public class Document : BaseEntity
    {
        public int AppointmentId { get; set; }
        public required string FileName { get; set; }
        public required string FilePath { get; set; }
        public required string DoctorDescription { get; set; }
        public required string AIDescription { get; set; }
        public DateTime UploadedAt { get; set; }

        // Navigation
        public required Patient Patient { get; set; }
    }

