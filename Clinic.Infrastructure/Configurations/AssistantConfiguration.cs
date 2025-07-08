using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        // Configure table name
        builder.ToTable("Assistants");

        // Configure properties
        builder.Property(a => a.HiredDate)
            .IsRequired();

        builder.Property(a => a.IsActive)
            .HasDefaultValue(true);

        builder.Property(a => a.Department)
            .HasMaxLength(100);

        builder.Property(a => a.Position)
            .HasMaxLength(100);

        builder.Property(a => a.Salary)
            .HasColumnType("decimal(18,2)");

        builder.Property(a => a.EmergencyContact)
            .HasMaxLength(200);

        builder.Property(a => a.EmergencyPhone)
            .HasMaxLength(20);

        builder.Property(a => a.Skills)
            .HasMaxLength(1000);

        builder.Property(a => a.Notes)
            .HasMaxLength(2000);

        builder.Property(a => a.Education)
            .HasMaxLength(500);

        builder.Property(a => a.CanManageAppointments)
            .HasDefaultValue(true);

        builder.Property(a => a.CanAccessPatientInfo)
            .HasDefaultValue(false);

        builder.Property(a => a.CanManageBilling)
            .HasDefaultValue(false);

        // Indexes
        builder.HasIndex(a => a.ClinicId)
            .HasDatabaseName("IX_Assistant_ClinicId");

        builder.HasIndex(a => a.IsActive)
            .HasDatabaseName("IX_Assistant_IsActive");

        builder.HasIndex(a => a.Department)
            .HasDatabaseName("IX_Assistant_Department");

        // Relationships
        builder.HasOne(a => a.Clinic)
            .WithMany(c => c.Assistants)
            .HasForeignKey(a => a.ClinicId)
            .OnDelete(DeleteBehavior.SetNull); // Assistant can exist without clinic

        // Relationship with Appointments
        builder.HasMany(a => a.ScheduledAppointments)
            .WithOne(ap => ap.Assistant)
            .HasForeignKey(ap => ap.AssistantId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relationship with Shifts
        builder.HasMany(a => a.Shifts)
            .WithOne(s => s.Assistant)
            .HasForeignKey(s => s.AssistantId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
