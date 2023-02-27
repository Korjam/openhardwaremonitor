using OpenHardwareMonitor.Modern.View;
using OpenHardwareMonitor.Modern.ViewModel;
using System.Windows;

namespace OpenHardwareMonitor.Modern;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        new MainWindow()
        {
            DataContext = new MainViewModel()
        }.Show();
    }
}
