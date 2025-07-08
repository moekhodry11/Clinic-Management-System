using Clinic.Domain.Enums;

namespace Clinic.Application.DTOs;

public class DoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    
    // Doctor-specific properties
    public int? ClinicId { get; set; }
    public string? ClinicName { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
    public string? Education { get; set; }
    public int YearsOfExperience { get; set; }
    public decimal ConsultationFee { get; set; }
    public string? Biography { get; set; }
    public bool IsActive { get; set; }
    public bool IsAvailableForBooking { get; set; }
    public DateTime? HiredDate { get; set; }
    public string? Department { get; set; }
    public string Role { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    
    public List<SpecialtyDto> Specializations { get; set; } = new();
    public List<ClinicShiftDto> Shifts { get; set; } = new();
}

public class CreateDoctorDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string PasswordHash { get; set; } = null!;
    
    // Doctor-specific properties
    public int ClinicId { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
    public string? Education { get; set; }
    public int YearsOfExperience { get; set; } = 0;
    public decimal ConsultationFee { get; set; } = 0;
    public string? Biography { get; set; }
    public string? Department { get; set; }
    
    public List<int> SpecializationIds { get; set; } = new();
}

public class UpdateDoctorDto
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public int? ClinicId { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
    public string? Education { get; set; }
    public int? YearsOfExperience { get; set; }
    public decimal? ConsultationFee { get; set; }
    public string? Biography { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsAvailableForBooking { get; set; }
    public string? Department { get; set; }
    
    public List<int>? SpecializationIds { get; set; }
}

public class SpecialtyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class ClinicShiftDto
{
    public int Id { get; set; }
    public string ShiftName { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int ClinicId { get; set; }
    public string? ClinicName { get; set; }
}

public class DoctorScheduleDto
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = null!;
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public List<AppointmentDto> Appointments { get; set; } = new();
    public int TotalAppointments { get; set; }
    public bool IsAvailable { get; set; }
    
    // Additional properties for views
    public int WeeklyShifts { get; set; }
    public int TotalHoursPerWeek { get; set; }
    public int UpcomingAppointments { get; set; }
    public List<DoctorWeeklyScheduleDto> WeeklySchedule { get; set; } = new();
}

public class DoctorAvailabilityDto
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = null!;
    public DateTime Date { get; set; }
    public List<DoctorTimeSlotDto> AvailableSlots { get; set; } = new();
}

public class DoctorTimeSlotDto
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
    public string? AppointmentId { get; set; }
}

public class DoctorStatsDto
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = null!;
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int UpcomingAppointments { get; set; }
    public int CancelledAppointments { get; set; }
    public decimal TotalRevenue { get; set; }
    public double AverageRating { get; set; }
    public int TotalPatients { get; set; }
    
    // Additional properties for views
    public int NewPatientsThisMonth { get; set; }
    public double AppointmentCompletionRate { get; set; }
    public int TotalReviews { get; set; }
    public decimal MonthlyRevenue { get; set; }
    public double RevenueGrowthPercentage { get; set; }
    public double MalePatientPercentage { get; set; }
    public double FemalePatientPercentage { get; set; }
    public int ScheduledAppointments { get; set; }
    public int NoShowAppointments { get; set; }
    public List<TopConditionDto> TopConditions { get; set; } = new();
    public double PatientSatisfactionScore { get; set; }
    public double OnTimePercentage { get; set; }
    public List<int> WeeklyAppointments { get; set; } = new();
}

public class DoctorStatisticsDto
{
    public int TotalAppointments { get; set; }
    public decimal TotalRevenue { get; set; }
    public int CompletedAppointments { get; set; }
    public int ScheduledAppointments { get; set; }
    public int CancelledAppointments { get; set; }
    public double AverageAppointmentDuration { get; set; }
    public int PatientCount { get; set; }
}

public class DoctorWeeklyScheduleDto
{
    public string DayName { get; set; } = null!;
    public DateTime Date { get; set; }
    public DoctorShiftDto? MorningShift { get; set; }
    public DoctorShiftDto? AfternoonShift { get; set; }
    public DoctorShiftDto? EveningShift { get; set; }
}

public class DoctorShiftDto
{
    public string ShiftName { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }
}

public class TopConditionDto
{
    public string ConditionName { get; set; } = null!;
    public int PatientCount { get; set; }
    public double Percentage { get; set; }
}
