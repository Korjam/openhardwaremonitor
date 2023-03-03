using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHardwareMonitor.Modern.View.Pages;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.Ui.Appearance;
using Wpf.Ui.Mvvm.Contracts;

namespace OpenHardwareMonitor.Modern.Services;

public class ApplicationLifeService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IThemeService _themeService;

    private INavigationWindow? _window;

    public ApplicationLifeService(IServiceProvider serviceProvider, IThemeService themeService)
    {
        _serviceProvider = serviceProvider;
        _themeService = themeService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        ConfigureLiveChartsTheme();

        Theme.Changed += Theme_Changed;

        _window = _serviceProvider.GetRequiredService<INavigationWindow>();
        _window.ShowWindow();

        _window.Navigate(typeof(DevicesPage));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Theme.Changed -= Theme_Changed;

        _window?.CloseWindow();
        _window = null;

        return Task.CompletedTask;
    }

    private void Theme_Changed(ThemeType currentTheme, Color systemAccent) =>
        ConfigureLiveChartsTheme(currentTheme);

    private void ConfigureLiveChartsTheme() =>
        ConfigureLiveChartsTheme(_themeService.GetSystemTheme());

    private void ConfigureLiveChartsTheme(ThemeType currentTheme)
    {
        LiveCharts.Configure(config =>
            _ = currentTheme switch
            {
                ThemeType.Dark => config.AddDarkTheme(),
                ThemeType.Light => config.AddLightTheme(),
                _ => config,
            });
    }
}
