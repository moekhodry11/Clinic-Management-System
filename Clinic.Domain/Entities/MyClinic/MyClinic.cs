namespace Clinic.Domain.Entities;

public class MyClinic : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? EstablishedDate { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public int SpecialtyId { get; set; }

    // Navigation properties
    public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    public virtual ICollection<Assistant> Assistants { get; set; } = new HashSet<Assistant>();
    public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    public virtual ICollection<ClinicShift> Shifts { get; set; } = new HashSet<ClinicShift>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    public required Specialty Specialty { get; set; }
    public virtual Subscription? Subscription { get; set; }
    public ICollection<ClinicShift> ClinicShifts { get; set; } = new HashSet<ClinicShift>();
    public ICollection<ClinicalDrug> ClinicalDrug { get; set; } = new HashSet<ClinicalDrug>();
}

