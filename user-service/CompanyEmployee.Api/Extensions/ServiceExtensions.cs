using CompanyEmployee.Api.Constants;
using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.Repositories;

namespace CompanyEmployee.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(ConfigurationConstants.CorsPolicy,
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}