using Microsoft.Extensions.Configuration;
using Microsoft.UI.Xaml;
using Pure.Coders.Toolboox.WinUI.ViewModels;
using Pure.Coders.Toolboox.WinUI.Views;
using System.IO;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pure.Coders.Toolboox.WinUI;
/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? _window;
    public static IConfiguration? Configuration { get; private set; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();

        // Build the configuration  
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Use the output directory  
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("options.json", optional: false, reloadOnChange: true)
            .Build();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        //_window = new MainWindow();
        //_window.Activate();
        _window = new Home();
        ((Home)_window).ViewModel = new HomeViewModel();
        _window.Activate();
    }
}
