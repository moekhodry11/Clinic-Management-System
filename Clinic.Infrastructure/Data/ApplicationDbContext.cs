using System.Reflection;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Clinic.Infrastructure.Data.Configuration;

namespace Clinic.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets for main entities
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Assistant> Assistants { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<MyClinic> Clinics { get; set; } = null!;
    public DbSet<Specialty> Specialties { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<Prescription> Prescriptions { get; set; } = null!;
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; } = null!;
    public DbSet<ClinicShift> ClinicShifts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}