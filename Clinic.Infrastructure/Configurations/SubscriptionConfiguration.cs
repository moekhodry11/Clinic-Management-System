using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.StartDate)
            .IsRequired();
            
        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.ClinicId)
            .IsRequired();

        // Configure one-to-one relationship with MyClinic
        // This is configured from the MyClinic side as well
        builder.HasOne(x => x.MyClinic)
            .WithOne(x => x.Subscription)
            .HasForeignKey<Subscription>(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
