using EmergencySystem.Application.DTOs;
using EmergencySystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmergencySystem.API.Middlewares;

public class GlobalErrorHandlerMiddelware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlerMiddelware> _logger;
    public GlobalErrorHandlerMiddelware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddelware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            _logger.LogError($"Validation Error. {ex.Message}");

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errors = ex.Errors
                            .GroupBy(x => x.PropertyName)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(x => x.ErrorMessage).ToList());

            var response = Response<object>.Failure(ErrorCodes.ValidationErrors, errors);

            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            throw;
        }
    }
}
