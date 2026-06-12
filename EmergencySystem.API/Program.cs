using EmergencySystem.API;
using EmergencySystem.API.Middlewares;
using EmergencySystem.Application;
using EmergencySystem.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication(builder.Configuration);

builder.Services.AddScoped<TransactionMiddleware>();

// Serilog Registration
builder.Logging.ClearProviders();

Serilog.Log.Logger = new Serilog.LoggerConfiguration()
       .Enrich.WithEnvironmentName()
       .Enrich.WithMachineName()
       .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
       .WriteTo.MSSqlServer(
           connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
           sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
           restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
       ) 
       .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlerMiddelware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
