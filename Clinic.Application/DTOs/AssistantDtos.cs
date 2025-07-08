using Clinic.Domain.Enums;

namespace Clinic.Application.DTOs;

public class AssistantDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Name => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public int ClinicId { get; set; }
    public string ClinicName { get; set; } = null!;
    public string? Department { get; set; }
    public string? Position { get; set; }
    public DateTime HiredDate { get; set; }
    public bool IsActive { get; set; }
    public int YearsOfExperience { get; set; }
    public string? Education { get; set; }
    public decimal? Salary { get; set; }
    public string? Skills { get; set; }
    public bool CanManageAppointments { get; set; }
    public bool CanAccessPatientInfo { get; set; }
    public bool CanManageBilling { get; set; }
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
    public string? Notes { get; set; }
    public int TotalAppointmentsScheduled { get; set; }
    public int WeeklyHours { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Additional properties for views
    public ICollection<ClinicShiftDto>? Shifts { get; set; }
    public int TotalWeeklyHours { get; set; }
    public ClinicShiftDto? NextShift { get; set; }
}

public class CreateAssistantDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public string Password { get; set; } = null!;
    public int ClinicId { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
    public DateTime? HiredDate { get; set; }
    public decimal? Salary { get; set; }
    public string? Education { get; set; }
    public int YearsOfExperience { get; set; }
    public string? Skills { get; set; }
    public bool CanManageAppointments { get; set; } = true;
    public bool CanAccessPatientInfo { get; set; } = false;
    public bool CanManageBilling { get; set; } = false;
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
    public string? Notes { get; set; }
}

public class UpdateAssistantDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public int ClinicId { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
    public DateTime? HiredDate { get; set; }
    public decimal? Salary { get; set; }
    public string? Education { get; set; }
    public int YearsOfExperience { get; set; }
    public string? Skills { get; set; }
    public bool CanManageAppointments { get; set; }
    public bool CanAccessPatientInfo { get; set; }
    public bool CanManageBilling { get; set; }
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; }
}

public class AssistantScheduleDto
{
    public int AssistantId { get; set; }
    public string AssistantName { get; set; } = null!;
    public DateTime Date { get; set; }
    public List<AssistantDailyScheduleDto> WeeklySchedule { get; set; } = new();
    public int WeeklyShifts { get; set; }
    public int TotalHoursPerWeek { get; set; }
    public int UpcomingAppointments { get; set; }
}

public class AssistantDailyScheduleDto
{
    public string DayName { get; set; } = null!;
    public DateTime Date { get; set; }
    public AssistantShiftDto? MorningShift { get; set; }
    public AssistantShiftDto? AfternoonShift { get; set; }
    public AssistantShiftDto? EveningShift { get; set; }
    public int AppointmentsScheduled { get; set; }
}

public class AssistantShiftDto
{
    public int Id { get; set; }
    public string ShiftName { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string Duration => $"{(EndTime - StartTime).TotalHours:F1} hours";
}

public class AssistantStatsDto
{
    public int AssistantId { get; set; }
    public string AssistantName { get; set; } = null!;
    public int TotalAppointmentsScheduled { get; set; }
    public int AppointmentsThisMonth { get; set; }
    public int AppointmentsThisWeek { get; set; }
    public int ActivePatients { get; set; }
    public decimal MonthlyEfficiencyRate { get; set; }
    public int AverageAppointmentsPerDay { get; set; }
    public int WeeklyHours { get; set; }
    public DateTime LastActiveDate { get; set; }
    public List<AssistantPerformanceMetricDto> PerformanceMetrics { get; set; } = new();
    public List<AssistantWeeklyStatsDto> WeeklyStats { get; set; } = new();
}

public class AssistantPerformanceMetricDto
{
    public string MetricName { get; set; } = null!;
    public decimal Value { get; set; }
    public string Unit { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class AssistantWeeklyStatsDto
{
    public int WeekNumber { get; set; }
    public int AppointmentsScheduled { get; set; }
    public int HoursWorked { get; set; }
    public decimal EfficiencyRate { get; set; }
}

public class AssistantAvailabilityDto
{
    public int AssistantId { get; set; }
    public string AssistantName { get; set; } = null!;
    public DateTime Date { get; set; }
    public List<TimeSlotDto> AvailableSlots { get; set; } = new();
    public bool IsAvailable { get; set; }
    public string? Department { get; set; }
}

public class TimeSlotDto
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
    public string? Reason { get; set; }
}

public class AssistantDailyShiftDto
{
    public int AssistantId { get; set; }
    public string AssistantName { get; set; } = null!;
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public List<AppointmentDto> Appointments { get; set; } = new();
}


