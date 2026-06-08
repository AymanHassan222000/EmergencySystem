using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class LocationPointConfigurations : IEntityTypeConfiguration<LocationPoint>
{
    public void Configure(EntityTypeBuilder<LocationPoint> builder)
    {
        builder.HasOne(lp => lp.Responder)
               .WithMany(r => r.LocationPoints)
               .HasForeignKey(lp => lp.ResponderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(lp => lp.Latitude)
               .IsRequired();

        builder.Property(lp => lp.Longitude)
               .IsRequired();

    }
}
