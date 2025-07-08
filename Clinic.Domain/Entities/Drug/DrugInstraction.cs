namespace Clinic.Domain.Entities
{
    public class DrugInstraction
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public required string Dosage { get; set; }
        //instractions

        public required Drug Drug { get; set; }
        public required ICollection<Prescription> Prescriptions { get; set; }
    }
}