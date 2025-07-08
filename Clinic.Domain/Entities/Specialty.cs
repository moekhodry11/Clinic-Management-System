namespace Clinic.Domain.Entities;

public class Specialty : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    // Navigation property for the many-to-many relationship with doctors
    public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
}
