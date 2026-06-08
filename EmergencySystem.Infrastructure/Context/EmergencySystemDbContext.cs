using Microsoft.EntityFrameworkCore;

namespace EmergencySystem.Infrastructure.Context;

public class EmergencySystemDbContext : DbContext
{
    public EmergencySystemDbContext(DbContextOptions<EmergencySystemDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmergencySystemDbContext).Assembly);

        base.OnModelCreating(modelBuilder);

    }


}
