namespace Clinic.Domain.Entities;
public class User : Person
{
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!; // Admin, Doctor, Employee
    public new DateTime CreatedAt { get; set; }
    //public ICollection<Clinic> clinics { get; set; } = new HashSet<Clinic>();
}