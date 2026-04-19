using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pure.Library.SQLite.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteDatabase<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        string? databaseName = configuration.GetSection($"{SqliteSettingsNames.Root}:{SqliteSettingsNames.DatabaseName}").Value!;
        string? applicationName = configuration.GetSection(SqliteSettingsNames.ApplicationName).Value!;
        string? databaseDirectoryName = configuration.GetSection($"{SqliteSettingsNames.Root}:{SqliteSettingsNames.DatabaseDirectoryName}").Value!;
        string path = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), applicationName, databaseDirectoryName, databaseName)}";
        SqliteConnectionStringBuilder connectionStringBuilder = new()
        {
            DataSource = path
        };
        services.AddDbContext<T>(options => options.UseSqlite(connectionStringBuilder.ConnectionString), ServiceLifetime.Transient);
        return services;
    }
}
