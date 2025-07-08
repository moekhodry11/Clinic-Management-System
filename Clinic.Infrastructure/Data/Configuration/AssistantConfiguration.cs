using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Data.Configuration;

public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        // Configure relationship with Clinic
        builder.HasOne(a => a.Clinic)
            .WithMany(c => c.Assistants)
            .HasForeignKey(a => a.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure one-to-many relationship with ClinicShifts
        builder.HasMany(a => a.Shifts)
            .WithOne(s => s.Assistant)
            .HasForeignKey(s => s.AssistantId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure one-to-many relationship with ScheduledAppointments
        builder.HasMany(a => a.ScheduledAppointments)
            .WithOne(app => app.Assistant)
            .HasForeignKey(app => app.AssistantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
