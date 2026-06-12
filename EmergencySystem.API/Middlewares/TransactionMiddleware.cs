
using EmergencySystem.Infrastructure.Context;

namespace EmergencySystem.API.Middlewares;

public class TransactionMiddleware : IMiddleware
{
    private readonly EmergencySystemDbContext _context;
    private readonly ILogger<TransactionMiddleware> _logger;
    public TransactionMiddleware(EmergencySystemDbContext context, ILogger<TransactionMiddleware> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            await next.Invoke(context);

            await transaction.CommitAsync();
        }
        catch (Exception ex) 
        {
            await transaction.RollbackAsync();

            _logger.LogError(
               ex,
               "Transaction rolled back for {Method} {Path}",
               context.Request.Method,
               context.Request.Path
            );

            throw;
        }
    }
}
