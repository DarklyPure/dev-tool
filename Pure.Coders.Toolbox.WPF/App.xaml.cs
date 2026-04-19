using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pure.Coders.Service;
using Pure.Coders.Service.Extensions;
using Pure.Coders.Toolbox.WPF.Extensions;
using Pure.Coders.Toolbox.WPF.Services;
using Pure.Coders.Toolbox.WPF.ViewModels;
using Pure.Coders.Toolbox.WPF.Views;
using System.IO;
using System.Windows;

namespace Pure.Coders.Toolbox.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration? Configuration { get; private set; }
    private IServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        // Build the configuration  
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Use the output directory  
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        IServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddAppSettings(Configuration);
        serviceCollection.AddLogging(Configuration);
        serviceCollection.AddUtilityServices();
        serviceCollection.AddWPFServices();
        serviceCollection.AddTransient<ICodersService, CodersService>();
        serviceCollection.AddSqliteDatabase(Configuration);
        serviceCollection.AddToolboxServices();

        _serviceProvider = serviceCollection.BuildServiceProvider();

        // Get the startup service and run an environment refresh
        StartupService startUpService = _serviceProvider.GetRequiredService<StartupService>();

        startUpService.RefreshEnvironment();

        ICodersService? codersService = _serviceProvider.GetRequiredService<ICodersService>();
        codersService.Initialise();

        Home v = new()
        {
            DataContext = _serviceProvider!.GetRequiredService<HomeViewModel>(),
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        v.Show();
    }
}
