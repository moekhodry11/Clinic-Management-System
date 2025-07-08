using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Data.Configuration;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.HasIndex(s => s.Name)
            .IsUnique();

        // Configure many-to-many relationship with Doctor
        builder.HasMany(s => s.Doctors)
            .WithMany(d => d.Specializations)
            .UsingEntity(j => j.ToTable("DoctorSpecialties"));
    }
}
