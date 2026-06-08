
using EmergencySystem.Infrastructure.Context;

namespace EmergencySystem.API.Middlewares;

public class TransactionMiddleware : IMiddleware
{
    private readonly EmergencySystemDbContext _context;
    public TransactionMiddleware(EmergencySystemDbContext context)
    {
        _context = context;
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
            throw;
        }
    }
}
