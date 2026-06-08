using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class IncidentLogConfigurations : IEntityTypeConfiguration<IncidentLog>
{
    public void Configure(EntityTypeBuilder<IncidentLog> builder)
    {
        builder.HasOne(il => il.User)
               .WithMany(r => r.IncidentLogs)
               .HasForeignKey(il => il.ChangedBy)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(il => il.Incident)
               .WithMany(i => i.IncidentLogs)
               .HasForeignKey(il => il.IncidentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(il => il.Notes)
               .HasMaxLength(1000)
               .IsRequired(false);
    }
}
