using EmergencySystem.Application.Interfaces;
using EmergencySystem.Infrastructure.Authentication;
using EmergencySystem.Infrastructure.Context;
using EmergencySystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;

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

        //JWT Configurations Registration
        services.Configure<JwtSettings>(configuration.GetSection("JWT"));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
            };
        });




        return services;
    }

}
