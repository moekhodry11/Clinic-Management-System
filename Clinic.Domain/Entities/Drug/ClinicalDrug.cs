namespace Clinic.Domain.Entities
{
    public class ClinicalDrug
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int ClinicId { get; set; }
        public required Drug Drug { get; set; }
        public required MyClinic MyClinic { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
