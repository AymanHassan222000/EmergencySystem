namespace EmergencySystem.API.Middlewares;

public class GlobalErrorHandlerMiddelware 
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlerMiddelware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
             await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
