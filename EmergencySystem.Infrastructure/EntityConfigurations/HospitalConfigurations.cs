using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class HospitalConfigurations : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.HasOne(h => h.ResourceAvailability)
               .WithOne(ra => ra.Hospital)
               .HasForeignKey<ResourceAvailability>(ra => ra.HospitalId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(h => h.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(h => h.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(h => h.Governorate)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(h => h.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(h => h.PhoneNumber)
               .HasMaxLength(15)
               .IsRequired();
    }
}
