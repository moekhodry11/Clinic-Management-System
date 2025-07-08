namespace Clinic.Domain.Entities;
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public required string Notes { get; set; }
        // Navigation
        public required DrugInstraction DrugInstraction { get; set; }
        public required Prescription Prescription { get; set; }
    }

