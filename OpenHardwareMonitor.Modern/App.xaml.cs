using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Model;
using OpenHardwareMonitor.Modern.Services;
using OpenHardwareMonitor.Modern.View;
using OpenHardwareMonitor.Modern.ViewModel;
using System.Windows;

namespace OpenHardwareMonitor.Modern;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<ISettings>(x => new Settings(@"C:\Temp\hardware-data.json"));
                services.AddTransient<Computer>();

                services.AddScoped<MainViewModel>();
                services.AddScoped<MainWindow>();

                services.AddHostedService<ApplicationLifeService>();
            })
            .Build();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _host.StartAsync().GetAwaiter().GetResult();
    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {
        _host.StopAsync().GetAwaiter().GetResult();
        _host.Dispose();
    }
}
