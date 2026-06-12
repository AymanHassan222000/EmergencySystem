using EmergencySystem.Application.Behaviors;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmergencySystem.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

        // FluentValidation Registration
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register the ValidationBehavior as a pipeline behavior for MediatR
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        TypeAdapterConfig.GlobalSettings.Scan(typeof(ApplicationDependencyInjection).Assembly);

        return services;
    }
}
