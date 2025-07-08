using Clinic.Domain.Enums;

namespace Clinic.Application.DTOs;

public class PatientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? SSN { get; set; }
    
    // Patient-specific properties
    public int? ClinicId { get; set; }
    public string? ClinicName { get; set; }
    public string Role { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    // Related data
    public List<AppointmentDto> Appointments { get; set; } = new();
    public List<DocumentDto> Documents { get; set; } = new();
    public List<ChronicDiseaseDto> ChronicDiseases { get; set; } = new();
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int UpcomingAppointments { get; set; }
    public DateTime? LastVisitDate { get; set; }
    public DateTime? NextAppointmentDate { get; set; }
}

public class CreatePatientDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? SSN { get; set; }
    public string PasswordHash { get; set; } = null!;
    
    // Patient-specific properties
    public int? ClinicId { get; set; }
    public List<int> ChronicDiseaseIds { get; set; } = new();
}

public class UpdatePatientDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? SSN { get; set; }
    public int? ClinicId { get; set; }
    public List<int>? ChronicDiseaseIds { get; set; }
}

public class DocumentDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string? DoctorDescription { get; set; }
    public string? AIDescription { get; set; }
    public DateTime UploadedAt { get; set; }
}

public class ChronicDiseaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class PatientStatsDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; } = null!;
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int UpcomingAppointments { get; set; }
    public int CancelledAppointments { get; set; }
    public decimal TotalAmountSpent { get; set; }
    public DateTime? LastVisitDate { get; set; }
    public DateTime? NextAppointmentDate { get; set; }
    public string? PrimaryDoctor { get; set; }
    public int TotalDocuments { get; set; }
    public List<ChronicDiseaseDto> ChronicDiseases { get; set; } = new();
    public List<PatientMonthlyVisitDto> MonthlyVisits { get; set; } = new();
    public double AverageVisitsPerMonth { get; set; }
    public int NoShowAppointments { get; set; }
    public double AttendanceRate { get; set; }
}

public class PatientMonthlyVisitDto
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int VisitCount { get; set; }
    public string MonthName { get; set; } = null!;
}

public class PatientSearchDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ClinicName { get; set; }
    public DateTime? LastVisitDate { get; set; }
    public int TotalAppointments { get; set; }
}

public class PatientAppointmentHistoryDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; } = null!;
    public List<AppointmentDto> Appointments { get; set; } = new();
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
} 