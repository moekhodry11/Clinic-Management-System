namespace Clinic.Domain.Entities;

public class ClinicShift : BaseEntity
{
    public int ClinicId { get; set; }
    public virtual MyClinic Clinic { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string? ShiftName { get; set; } // e.g., "Morning", "Afternoon", "Evening"
    public bool IsActive { get; set; } = true;
    
    public int? DoctorId { get; set; }
    public int? AssistantId { get; set; }

    // Navigation properties - one-to-many relationships
    public Doctor? Doctor { get; set; }
    public Assistant? Assistant { get; set; }
}
