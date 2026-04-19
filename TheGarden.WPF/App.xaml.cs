using System.Windows;
using TheGarden.WPF.ViewModels;
using TheGarden.WPF.Views;

namespace TheGarden.WPF;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Home v = new();
        HomeViewModel vm = new();

        v.DataContext = vm;
    }
}

