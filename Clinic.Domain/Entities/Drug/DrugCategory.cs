namespace Clinic.Domain.Entities
{
    public class DrugCategory : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}