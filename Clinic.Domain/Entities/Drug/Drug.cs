namespace Clinic.Domain.Entities
{
    public class Drug
    {
        public int Id { get; set; }
        public required string DrugName { get; set; }
        public required string Description { get; set; }
        public required string ScintifcName { get; set; } // (active ingredient)
        public required DrugCategory Category { get; set; }
    }
}