namespace Clinic.Domain.Entities;

public class Assistant : User
{
    // Relationship with clinic
    public int ClinicId { get; set; }
    public virtual MyClinic Clinic { get; set; } = null!;

    // Assistant-specific properties
    public DateTime HiredDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public string? Department { get; set; } // Reception, Scheduling, Administration, etc.
    public string? Position { get; set; } // Title/Position (e.g., Senior Receptionist, Office Manager)
    public decimal? Salary { get; set; }
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
    public string? Skills { get; set; } // Comma-separated skills
    public string? Notes { get; set; } // Additional notes about the assistant
    public int YearsOfExperience { get; set; }
    public string? Education { get; set; }
    public bool CanManageAppointments { get; set; } = true;
    public bool CanAccessPatientInfo { get; set; } = false;
    public bool CanManageBilling { get; set; } = false;

    // Navigation properties for appointments they handle
    public virtual ICollection<Appointment> ScheduledAppointments { get; set; } = new HashSet<Appointment>();
    
    // Navigation properties for shifts they work
    public virtual ICollection<ClinicShift> Shifts { get; set; } = new HashSet<ClinicShift>();

    // Helper methods for appointment management
    public bool CanScheduleAppointments()
    {
        return IsActive && CanManageAppointments && 
               (Department == "Reception" || Department == "Scheduling" || string.IsNullOrEmpty(Department));
    }

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
        return ScheduledAppointments.Count(appointment => 
            appointment.AppointmentDate.Date == date.Date);
    }

    public int GetTotalWeeklyHours()
    {
        return (int)Math.Round(Shifts.Sum(shift => 
            (shift.EndTime - shift.StartTime).TotalHours));
    }

    public bool HasSkill(string skill)
    {
        return !string.IsNullOrEmpty(Skills) && 
               Skills.Contains(skill, StringComparison.OrdinalIgnoreCase);
    }

    public List<string> GetSkillsList()
    {
        return string.IsNullOrEmpty(Skills) 
            ? new List<string>() 
            : Skills.Split(',').Select(s => s.Trim()).ToList();
    }

    public void AddSkill(string skill)
    {
        var currentSkills = GetSkillsList();
        if (!currentSkills.Contains(skill, StringComparer.OrdinalIgnoreCase))
        {
            currentSkills.Add(skill);
            Skills = string.Join(", ", currentSkills);
        }
    }

    public void RemoveSkill(string skill)
    {
        var currentSkills = GetSkillsList();
        currentSkills.RemoveAll(s => s.Equals(skill, StringComparison.OrdinalIgnoreCase));
        Skills = string.Join(", ", currentSkills);
    }
}
