using Clinic.Domain.Entities;

namespace Clinic.Domain.Entities;

public class Doctor : User
{
    // Relationship with clinic
    public int ClinicId { get; set; }
    public virtual MyClinic Clinic { get; set; } = null!;

    // Doctor-specific properties
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
    public string? Education { get; set; }
    public int YearsOfExperience { get; set; } = 0;
    public decimal ConsultationFee { get; set; } = 0;
    public string? Biography { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsAvailableForBooking { get; set; } = true;
    public DateTime? HiredDate { get; set; }
    public string? Department { get; set; }

    // Navigation properties
    public ICollection<ClinicShift> Shifts { get; set; } = new HashSet<ClinicShift>();
    public ICollection<Specialty> Specializations { get; set; } = new HashSet<Specialty>();
    public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();

    // Helper methods for appointment management
    public bool IsWorkingOn(DayOfWeek dayOfWeek, TimeSpan time)
    {
        return Shifts.Any(shift => 
            shift.DayOfWeek == dayOfWeek && 
            time >= shift.StartTime && 
            time <= shift.EndTime);
    }

    public IEnumerable<ClinicShift> GetShiftsForDay(DayOfWeek dayOfWeek)
    {
        return Shifts.Where(shift => shift.DayOfWeek == dayOfWeek);
    }

    public int GetAppointmentsCountForDate(DateTime date)
    {
        return Appointments.Count(appointment => 
            appointment.AppointmentDate.Date == date.Date);
    }

    public bool CanTakeAppointment(DateTime appointmentDate, TimeSpan appointmentTime)
    {
        if (!IsActive || !IsAvailableForBooking)
            return false;

        return IsWorkingOn(appointmentDate.DayOfWeek, appointmentTime);
    }

    public TimeSpan GetTotalWorkingHoursForDay(DayOfWeek dayOfWeek)
    {
        var dayShifts = GetShiftsForDay(dayOfWeek);
        return dayShifts.Aggregate(TimeSpan.Zero, (total, shift) => 
            total.Add(shift.EndTime - shift.StartTime));
    }

    public bool HasSpecialty(int specialtyId)
    {
        return Specializations.Any(s => s.Id == specialtyId);
    }

    public bool HasValidLicense()
    {
        return !string.IsNullOrEmpty(LicenseNumber) && 
               (LicenseExpiryDate == null || LicenseExpiryDate > DateTime.UtcNow);
    }
}