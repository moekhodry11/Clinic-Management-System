using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities;

public class Appointment : BaseEntity
{
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } = null!;

    public int? AssistantId { get; set; }
    public virtual Assistant? Assistant { get; set; }

    public int ClinicId { get; set; }
    public virtual MyClinic Clinic { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled, No-Show
    public string? Notes { get; set; }
    public string? Reason { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public string? CancellationReason { get; set; }
    public string? Diagnosis { get; set; }
    public string? Treatment { get; set; }

    // Additional properties from merged class
    public decimal Cost { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public int DurationMinutes { get; set; } = 30; // Default 30 minutes
    
    // Check-in timestamps
    public DateTime? PatientCheckInDate { get; set; }
    public DateTime? AssistantCheckInDate { get; set; }
    public DateTime? DoctorCheckInDate { get; set; }
    public string? Summary { get; set; }

    // Navigation properties for prescriptions given during this appointment
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}
