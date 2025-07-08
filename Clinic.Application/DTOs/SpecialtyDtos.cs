using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.DTOs;

public class SpecialtyDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    // Statistics
    public int DoctorsCount { get; set; }
    public int ClinicsCount { get; set; }
    public int AppointmentsCount { get; set; }
    public int ActiveDoctorsCount { get; set; }
    
    // Related data
    public List<DoctorSummaryDto> Doctors { get; set; } = new();
    public List<ClinicSummaryDto> Clinics { get; set; } = new();
}

public class CreateSpecialtyDto
{
    [Required(ErrorMessage = "Specialty name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Specialty name must be between 2 and 100 characters")]
    public string Name { get; set; } = null!;
}

public class UpdateSpecialtyDto
{
    [Required(ErrorMessage = "Specialty name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Specialty name must be between 2 and 100 characters")]
    public string Name { get; set; } = null!;
}

public class SpecialtyStatsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int TotalDoctors { get; set; }
    public int ActiveDoctors { get; set; }
    public int InactiveDoctors { get; set; }
    public int ClinicsUsingSpecialty { get; set; }
    public int TotalAppointments { get; set; }
    public int TodayAppointments { get; set; }
    public int ThisMonthAppointments { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal MonthlyRevenue { get; set; }
    public decimal AverageConsultationFee { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Top performing metrics
    public List<DoctorPerformanceDto> TopDoctors { get; set; } = new();
    public List<MonthlyStatsDto> MonthlyStats { get; set; } = new();
}

public class DoctorSummaryDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal ConsultationFee { get; set; }
    public int YearsOfExperience { get; set; }
    public bool IsActive { get; set; }
    public bool IsAvailableForBooking { get; set; }
    public string? ClinicName { get; set; }
    public int AppointmentsCount { get; set; }
}

public class ClinicSummaryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; }
    public int DoctorsCount { get; set; }
    public int AppointmentsCount { get; set; }
}

public class DoctorPerformanceDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int AppointmentsCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal AverageRating { get; set; }
    public string? ClinicName { get; set; }
}

public class MonthlyStatsDto
{
    public int Month { get; set; }
    public int Year { get; set; }
    public string MonthName { get; set; } = null!;
    public int AppointmentsCount { get; set; }
    public decimal Revenue { get; set; }
    public int ActiveDoctorsCount { get; set; }
}
