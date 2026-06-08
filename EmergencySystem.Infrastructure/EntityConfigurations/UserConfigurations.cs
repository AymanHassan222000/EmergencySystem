using EmergencySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystem.Infrastructure.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.UserName)
                .IsUnique();

        builder.Property(u => u.UserName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasMaxLength(200)
               .IsRequired();

        builder.HasIndex(u => u.Email)
               .IsUnique();

    }
}
