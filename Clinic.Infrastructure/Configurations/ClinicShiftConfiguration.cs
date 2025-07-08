using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class ClinicShiftConfiguration : IEntityTypeConfiguration<ClinicShift>
{
    public void Configure(EntityTypeBuilder<ClinicShift> builder)
    {
        // Required properties
        builder.Property(s => s.ShiftName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.StartTime)
            .IsRequired();

        builder.Property(s => s.EndTime)
            .IsRequired();

        builder.Property(s => s.DayOfWeek)
            .IsRequired();

        // Foreign key properties - these are now int, not string
        // No need to specify MaxLength for int properties

        // Relationships
        builder.HasOne(s => s.Clinic)
            .WithMany(c => c.ClinicShifts)
            .HasForeignKey(s => s.ClinicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Doctor)
            .WithMany(d => d.Shifts)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Assistant)
            .WithMany(a => a.Shifts)
            .HasForeignKey(s => s.AssistantId)
            .OnDelete(DeleteBehavior.NoAction);

        // Indexes
        builder.HasIndex(s => new { s.ClinicId, s.DayOfWeek })
            .HasDatabaseName("IX_ClinicShift_Clinic_Day");

        builder.HasIndex(s => s.DoctorId)
            .HasDatabaseName("IX_ClinicShift_Doctor");

        builder.HasIndex(s => s.AssistantId)
            .HasDatabaseName("IX_ClinicShift_Assistant");

        // Ensure no overlapping shifts for the same person on the same day
        builder.HasIndex(s => new { s.DoctorId, s.DayOfWeek, s.StartTime, s.EndTime })
            .HasDatabaseName("IX_ClinicShift_Doctor_Schedule")
            .IsUnique()
            .HasFilter("DoctorId IS NOT NULL");

        builder.HasIndex(s => new { s.AssistantId, s.DayOfWeek, s.StartTime, s.EndTime })
            .HasDatabaseName("IX_ClinicShift_Assistant_Schedule")
            .IsUnique()
            .HasFilter("AssistantId IS NOT NULL");
    }
}
