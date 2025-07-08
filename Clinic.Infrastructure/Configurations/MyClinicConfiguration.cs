using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class MyClinicConfiguration : IEntityTypeConfiguration<MyClinic>
{
    public void Configure(EntityTypeBuilder<MyClinic> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);
            
        builder.Property(x => x.Email)
            .HasMaxLength(100);

        // Configure relationship with Specialty
        builder.HasOne(x => x.Specialty)
            .WithMany()
            .HasForeignKey(x => x.SpecialtyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure one-to-one relationship with Subscription
        builder.HasOne(x => x.Subscription)
            .WithOne(x => x.MyClinic)
            .HasForeignKey<Subscription>(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure other relationships
        builder.HasMany(x => x.Doctors)
            .WithOne(x => x.Clinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Patients)
            .WithOne(x => x.MyClinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Assistants)
            .WithOne(x => x.Clinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Clinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ClinicShifts)
            .WithOne(x => x.Clinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ClinicalDrug)
            .WithOne(x => x.MyClinic)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
