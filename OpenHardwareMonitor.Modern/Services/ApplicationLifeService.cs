using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHardwareMonitor.Modern.View;
using OpenHardwareMonitor.Modern.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHardwareMonitor.Modern.Services;

public class ApplicationLifeService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private MainWindow? _window;

    public ApplicationLifeService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _window = _serviceProvider.GetRequiredService<MainWindow>();
        _window.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        _window.Show();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _window?.Close();
        _window = null;

        return Task.CompletedTask;
    }
}
