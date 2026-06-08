using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class IncidentConfigurations : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.HasOne(i => i.Reporter)
               .WithMany(u => u.ReportedIncidents)
               .HasForeignKey(i => i.ReporterId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(1000);

    }
}
