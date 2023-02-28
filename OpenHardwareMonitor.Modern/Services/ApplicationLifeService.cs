using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHardwareMonitor.Modern.View.Pages;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wpf.Ui.Contracts;

namespace OpenHardwareMonitor.Modern.Services;

public class ApplicationLifeService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    private INavigationWindow? _window;

    public ApplicationLifeService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _window = _serviceProvider.GetRequiredService<INavigationWindow>();
        _window.ShowWindow();

        _window.Navigate(typeof(DevicesPage));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _window?.CloseWindow();
        _window = null;

        return Task.CompletedTask;
    }
}
