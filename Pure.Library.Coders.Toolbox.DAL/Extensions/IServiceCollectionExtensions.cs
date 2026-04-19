using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pure.Library.SQLite.Extensions;

namespace Pure.Library.Coders.Toolbox.DAL.Extensions;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds a Sqlite database based <see cref="DbContext"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="builder">A <see cref="SqliteConnectionStringBuilder"/> instance.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddSqliteDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? dataSource = configuration.GetSection("SqliteConnectionConfig:DataSource").Value!;
        string? applicationName = configuration.GetSection("AppSettings:ApplicationName").Value!;
        string path = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), applicationName,"Data", dataSource)}";
        // services.AddDbContext<DeveloperToolboxContext>(options => options.UseSqlite($"Data Source={config.DataSource}"), ServiceLifetime.Transient);
        return services;
    }
}
