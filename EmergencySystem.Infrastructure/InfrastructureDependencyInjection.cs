using EmergencySystem.Application.Interfaces;
using EmergencySystem.Infrastructure.Context;
using EmergencySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmergencySystem.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //DbContext Registration
        services.AddDbContext<EmergencySystemDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                   .EnableSensitiveDataLogging()
                   .LogTo(log => Console.WriteLine(log), LogLevel.Information);
        });

        //General Repository Registration
        services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));

        return services;
    }

}
