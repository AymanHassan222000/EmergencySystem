using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class IncidentAssignmentConfigurations : IEntityTypeConfiguration<IncidentAssignment>
{
    public void Configure(EntityTypeBuilder<IncidentAssignment> builder)
    {
        builder.HasOne(ia => ia.Incident)
               .WithMany(i => i.Assignments)
               .HasForeignKey(ia => ia.IncidentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ia => ia.Responder)
               .WithMany(r => r.IncidentAssignments)
               .HasForeignKey(ia => ia.ResponderId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}