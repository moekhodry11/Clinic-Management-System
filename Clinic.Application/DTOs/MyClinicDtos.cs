using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.DTOs;

public class MyClinicDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int SpecialtyId { get; set; }
    public string? SpecialtyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    // Navigation properties counts
    public int DoctorsCount { get; set; }
    public int PatientsCount { get; set; }
    public int AssistantsCount { get; set; }
    public int AppointmentsCount { get; set; }
    
    // Subscription info
    public bool HasActiveSubscription { get; set; }
    public DateTime? SubscriptionExpiryDate { get; set; }
}

public class CreateMyClinicDto
{
    [Required(ErrorMessage = "Clinic name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; } = null!;
    
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string Address { get; set; } = null!;
    
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; } = null!;
    
    [Required(ErrorMessage = "Specialty is required")]
    public int SpecialtyId { get; set; }
}

public class UpdateMyClinicDto
{
    [Required(ErrorMessage = "Clinic name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; } = null!;
    
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string Address { get; set; } = null!;
    
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; } = null!;
    
    [Required(ErrorMessage = "Specialty is required")]
    public int SpecialtyId { get; set; }
}

public class MyClinicStatsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int TotalDoctors { get; set; }
    public int ActiveDoctors { get; set; }
    public int TotalPatients { get; set; }
    public int TotalAssistants { get; set; }
    public int TotalAppointments { get; set; }
    public int TodayAppointments { get; set; }
    public int PendingAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal MonthlyRevenue { get; set; }
    public bool HasActiveSubscription { get; set; }
    public DateTime? SubscriptionExpiryDate { get; set; }
}
