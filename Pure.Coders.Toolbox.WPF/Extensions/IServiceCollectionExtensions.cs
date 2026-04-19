using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pure.Coders.Service;
using Pure.Coders.Service.Extensions;
using Pure.Coders.Toolbox.WPF.Models;
using Pure.Coders.Toolbox.WPF.Services;
using Pure.Coders.Toolbox.WPF.ViewModels;
using Pure.Coders.Toolbox.WPF.Views;
using Pure.Library.Coders.Toolbox;
using Pure.Library.Logging.Extensions;
using Pure.Library.Services;
using System.IO;

namespace Pure.Coders.Toolbox.WPF.Extensions;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="AppSettings"/> instance to the services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        // Get the config
        AppSettings appSettings = configuration.Get<AppSettings>()!;

        services.AddSingleton<AppSettings>(appSettings);
        return services;
    }

    public static IServiceCollection AddUtilityServices(this IServiceCollection services)
    {
        services.AddSingleton<StartupService>();
        services.AddSingleton<DirectoryManagementService>();
        return services;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
    {
        // Get the config
        AppSettings appSettings = configuration.Get<AppSettings>()!;

        // Derive the log directory
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), appSettings.ApplicationName, appSettings.LogsDirectory);

        ILoggerFactory _loggerFactory = LoggerFactory.Create(
            loggerBuilder =>
            {
                loggerBuilder.AddRollingLogFile(
                            appSettings.ApplicationName!,
                            logDirectory: path,
                            maxFileSizeMB: 50,
                            maxFileCount: 50,
                            queueCapacity: 2000);
            });

        services.AddSingleton<ILogger>(_loggerFactory.CreateLogger<Home>());
        return services;
    }

    public static IServiceCollection AddWPFServices(this IServiceCollection services)
    {
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<CodeGeneratorViewModel>();

        return services;
    }

    public static IServiceCollection AddToolboxServices(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddTransient<ICodersService, CodersService>();
        services.AddTransient<CachedData>();
        return services;
    }
}
