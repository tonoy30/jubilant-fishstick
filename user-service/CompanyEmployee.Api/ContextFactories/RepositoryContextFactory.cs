using CompanyEmployee.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyEmployee.Api.ContextFactories;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder =
            new DbContextOptionsBuilder<RepositoryContext>().UseNpgsql(
                configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("CompanyEmployee.Api"));

        return new RepositoryContext(builder.Options);
    }
}