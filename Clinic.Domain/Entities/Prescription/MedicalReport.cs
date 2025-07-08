namespace Clinic.Domain.Entities;
    public class MedicalReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Document Document { get; set; }
    }