using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities;

public class Person : BaseEntity
{
    [Required]
    [StringLength(11)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    [StringLength(20)]
    public string? SSN { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    [EmailAddress]
    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? Street { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }
}