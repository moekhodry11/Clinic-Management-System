using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Data.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        // Configure relationship with Clinic
        builder.HasOne(d => d.Clinic)
            .WithMany(c => c.Doctors)
            .HasForeignKey(d => d.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure many-to-many relationship with Specialties
        builder.HasMany(d => d.Specializations)
            .WithMany(s => s.Doctors)
            .UsingEntity(j => j.ToTable("DoctorSpecialties"));

        // Configure one-to-many relationship with ClinicShifts
        builder.HasMany(d => d.Shifts)
            .WithOne(s => s.Doctor)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure one-to-many relationship with Appointments
        builder.HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure one-to-many relationship with Prescriptions
        builder.HasMany(d => d.Prescriptions)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
