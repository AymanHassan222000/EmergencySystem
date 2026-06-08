using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class CitizenProfileConfigurations : IEntityTypeConfiguration<CitizenProfile>
{
    public void Configure(EntityTypeBuilder<CitizenProfile> builder)
    {
        builder.HasOne(cp => cp.User)
               .WithOne(u => u.CitizenProfile)
               .HasForeignKey<CitizenProfile>(cp => cp.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(cp => cp.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(cp => cp.MiddleName)
               .HasMaxLength(100);

        builder.Property(cp => cp.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(cp => cp.PhoneNumber)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(cp => cp.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(cp => cp.Governorate)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(cp => cp.City)
               .IsRequired()
               .HasMaxLength(100);

    }
}
