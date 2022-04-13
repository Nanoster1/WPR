using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WPR.Data;

namespace WPR.Migrations;

public class Factory : IDesignTimeDbContextFactory<WprDbContext>
{
    public WprDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true);

        var configuration = configurationBuilder.Build();
        var connectionString = configuration.GetConnectionString("Database");

        var optionsBuilder = new DbContextOptionsBuilder<WprDbContext>()
            .UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(Factory).Assembly.GetName().Name))
            .UseSnakeCaseNamingConvention();

        return new WprDbContext(optionsBuilder.Options);
    }
}