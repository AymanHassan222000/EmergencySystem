using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(v => v.PlateNumber)
               .HasMaxLength(15)
               .IsRequired();

    }
}
