using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        // Table name
        builder.ToTable("Specialties");

        // Primary key
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Unique constraint on Name for non-deleted records
        builder.HasIndex(s => s.Name)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0")
            .HasDatabaseName("IX_Specialties_Name_Unique");

        // Relationships
        builder.HasMany(s => s.Doctors)
            .WithMany(d => d.Specializations)
            .UsingEntity<Dictionary<string, object>>(
                "DoctorSpecialty",
                j => j.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId"),
                j => j.HasOne<Specialty>().WithMany().HasForeignKey("SpecialtyId"),
                j =>
                {
                    j.HasKey("DoctorId", "SpecialtyId");
                    j.ToTable("DoctorSpecialties");
                });

        // Soft delete filter
        builder.HasQueryFilter(s => !s.IsDeleted);
    }
}
