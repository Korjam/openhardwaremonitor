using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Model;
using OpenHardwareMonitor.Modern.Services;
using OpenHardwareMonitor.Modern.View;
using OpenHardwareMonitor.Modern.View.Pages;
using OpenHardwareMonitor.Modern.ViewModel;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

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
                services.AddHostedService<ApplicationLifeService>();

                services.AddSingleton<ISettings>(x => new Settings(@"C:\Temp\hardware-data.json"));
                services.AddTransient<Computer>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // Taskbar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Snackbar service
                services.AddSingleton<ISnackbarService, SnackbarService>();

                // Dialog service
                services.AddSingleton<IDialogService, DialogService>();

                // Tray icon
                //services.AddSingleton<INotifyIconService, NotifyIconService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                services.AddScoped<MainViewModel>();
                services.AddScoped<INavigationWindow, MainWindow>();

                services.AddScoped<DevicesViewModel>();
                services.AddScoped<DevicesPage>();

                //services.AddScoped<SettingsViewModel>();
                services.AddScoped<SettingsPage>();
            })
            .Build();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        LiveCharts.Configure(config =>
            config
                // registers SkiaSharp as the library backend
                // REQUIRED unless you build your own
                .AddSkiaSharp()

                // adds the default supported types
                // OPTIONAL but highly recommend
                .AddDefaultMappers()

                // select a theme, default is Light
                // OPTIONAL
                .AddDarkTheme()
                //.AddLightTheme()

                // finally register your own mappers
                // you can learn more about mappers at:
                // ToDo add website link...
                //.HasMap<City>((city, point) =>
                //{
                //    point.PrimaryValue = city.Population;
                //    point.SecondaryValue = point.Context.Index;
                //})
                // .HasMap<Foo>( .... )
                // .HasMap<Bar>( .... )
            );

        _host.StartAsync().GetAwaiter().GetResult();
    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {
        _host.StopAsync().GetAwaiter().GetResult();
        _host.Dispose();
    }
}
