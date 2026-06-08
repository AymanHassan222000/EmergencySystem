using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class TransferRequestConfigurations : IEntityTypeConfiguration<TransferRequest>
{
    public void Configure(EntityTypeBuilder<TransferRequest> builder)
    {
        builder.HasOne(tr => tr.Incident)
               .WithMany(i => i.TransferRequests)
               .HasForeignKey(tr => tr.IncidentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tr => tr.Hospital)
               .WithMany(h => h.TransferRequests)
               .HasForeignKey(tr => tr.HospitalId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tr => tr.User)
               .WithMany(u => u.TransferRequests)
               .HasForeignKey(tr => tr.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(tr => tr.Notes)
               .HasMaxLength(500);
    }
}
