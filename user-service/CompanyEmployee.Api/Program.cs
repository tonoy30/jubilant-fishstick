using CompanyEmployee.Api.Constants;
using CompanyEmployee.Api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    // Configure Serilog
    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.ConfigureCors();
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureServiceManager();
    builder.Services.ConfigureNpgsqlContext(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.ConfigureExceptionHandler();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });

    app.UseCors(ConfigurationConstants.CorsPolicy);

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}