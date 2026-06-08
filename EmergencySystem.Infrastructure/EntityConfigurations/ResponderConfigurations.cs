using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class ResponderConfigurations : IEntityTypeConfiguration<Responder>
{
    public void Configure(EntityTypeBuilder<Responder> builder)
    {
        builder.HasOne(r => r.User)
               .WithMany(u => u.Responders)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(r => r.BadgeNumber)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(r => r.Specialization)
               .HasMaxLength(255);
    }
}
