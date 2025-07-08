using Clinic.Domain.Enums;

namespace Clinic.Application.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; } = null!;
    public int ClinicId { get; set; }
    public string ClinicName { get; set; } = null!;
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = null!;
    public int? AssistantId { get; set; }
    public string? AssistantName { get; set; }
    
    public decimal Cost { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public int DurationMinutes { get; set; }
    
    public DateTime? PatientCheckInDate { get; set; }
    public DateTime? AssistantCheckInDate { get; set; }
    public DateTime? DoctorCheckInDate { get; set; }
    
    public string? Summary { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateAppointmentDto
{
    public int PatientId { get; set; }
    public int ClinicId { get; set; }
    public int DoctorId { get; set; }
    public int? AssistantId { get; set; }
    
    public decimal Cost { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public int DurationMinutes { get; set; } = 30;
    
    public string? Notes { get; set; }
}

public class UpdateAppointmentDto
{
    public int Id { get; set; }
    public AppointmentStatus? AppointmentStatus { get; set; }
    public DateTime? AppointmentDate { get; set; }
    public TimeSpan? AppointmentTime { get; set; }
    public int? DurationMinutes { get; set; }
    public decimal? Cost { get; set; }
    public string? Notes { get; set; }
    public string? Summary { get; set; }
}
