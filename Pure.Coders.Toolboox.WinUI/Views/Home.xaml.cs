using Microsoft.UI.Xaml;
using Pure.Coders.Toolboox.WinUI.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pure.Coders.Toolboox.WinUI.Views;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Home : Window
{
    public Home()
    {
        InitializeComponent();
    }

    public HomeViewModel? ViewModel { get; set; }
}
