using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        // Primary key is inherited from BaseEntity

        // Required properties
        builder.Property(a => a.DoctorId)
            .IsRequired()
            .HasMaxLength(450); // Standard ASP.NET Identity user ID length

        builder.Property(a => a.AssistantId)
            .HasMaxLength(450);

        builder.Property(a => a.Cost)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(a => a.AppointmentType)
            .IsRequired();

        builder.Property(a => a.AppointmentStatus)
            .IsRequired();

        builder.Property(a => a.AppointmentDate)
            .IsRequired();

        builder.Property(a => a.AppointmentTime)
            .IsRequired();

        builder.Property(a => a.DurationMinutes)
            .IsRequired()
            .HasDefaultValue(30);

        builder.Property(a => a.Summary)
            .HasMaxLength(500);

        builder.Property(a => a.Notes)
            .HasMaxLength(1000);

        // Relationships
        builder.HasOne(a => a.Clinic)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Assistant)
            .WithMany(ast => ast.ScheduledAppointments)
            .HasForeignKey(a => a.AssistantId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(a => a.AppointmentDate)
            .HasDatabaseName("IX_Appointment_Date");

        builder.HasIndex(a => new { a.ClinicId, a.AppointmentDate })
            .HasDatabaseName("IX_Appointment_Clinic_Date");

        builder.HasIndex(a => new { a.DoctorId, a.AppointmentDate })
            .HasDatabaseName("IX_Appointment_Doctor_Date");

        builder.HasIndex(a => a.PatientId)
            .HasDatabaseName("IX_Appointment_Patient");

        builder.HasIndex(a => a.AssistantId)
            .HasDatabaseName("IX_Appointment_Assistant");
    }
}
