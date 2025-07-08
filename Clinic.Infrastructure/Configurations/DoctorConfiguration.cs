using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        // Doctor inherits from User, so most properties are configured in UserConfiguration
        
        // Doctor-specific properties
        builder.Property(d => d.LicenseNumber)
            .HasMaxLength(50);

        builder.Property(d => d.Education)
            .HasMaxLength(500);

        builder.Property(d => d.Biography)
            .HasMaxLength(2000);

        builder.Property(d => d.Department)
            .HasMaxLength(100);

        builder.Property(d => d.ConsultationFee)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(d => d.YearsOfExperience)
            .HasDefaultValue(0);

        builder.Property(d => d.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(d => d.IsAvailableForBooking)
            .IsRequired()
            .HasDefaultValue(true);

        // Relationship with Clinic
        builder.HasOne(d => d.Clinic)
            .WithMany(c => c.Doctors)
            .HasForeignKey(d => d.ClinicId)
            .OnDelete(DeleteBehavior.SetNull); // Doctor can exist without clinic

        // Relationship with Appointments
        builder.HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion if doctor has appointments

        // Relationship with Shifts
        builder.HasMany(d => d.Shifts)
            .WithOne(s => s.Doctor)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        // Relationship with Prescriptions
        builder.HasMany(d => d.Prescriptions)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Many-to-many relationship with Specialties
        builder.HasMany(d => d.Specializations)
            .WithMany(s => s.Doctors)
            .UsingEntity(j => j.ToTable("DoctorSpecialties"));

        // Indexes
        builder.HasIndex(d => d.LicenseNumber)
            .HasDatabaseName("IX_Doctor_LicenseNumber")
            .IsUnique()
            .HasFilter("LicenseNumber IS NOT NULL");

        builder.HasIndex(d => d.ClinicId)
            .HasDatabaseName("IX_Doctor_ClinicId");

        builder.HasIndex(d => new { d.ClinicId, d.IsActive })
            .HasDatabaseName("IX_Doctor_Clinic_Active");

        builder.HasIndex(d => new { d.IsActive, d.IsAvailableForBooking })
            .HasDatabaseName("IX_Doctor_Availability");
    }
}
