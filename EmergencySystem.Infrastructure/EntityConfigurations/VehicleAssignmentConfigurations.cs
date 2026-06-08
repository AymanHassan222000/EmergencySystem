using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations
{
    public class VehicleAssignmentConfigurations : IEntityTypeConfiguration<VehicleAssignment>
    {
        public void Configure(EntityTypeBuilder<VehicleAssignment> builder)
        {
            builder.HasOne(va => va.Vehicle)
                   .WithMany(v => v.VehicleAssignments)
                   .HasForeignKey(va => va.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(va => va.Responder)
                    .WithMany(r => r.VehicleAssignments)
                    .HasForeignKey(va => va.ResponderId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
