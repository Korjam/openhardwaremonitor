using CommunityToolkit.Mvvm.ComponentModel;
using OpenHardwareMonitor.Hardware;
using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        var computer = new Computer()
        {
            CPUEnabled = true,
            FanControllerEnabled = true,
            GPUEnabled = true,
            HDDEnabled = true,
            MainboardEnabled = true,
            RAMEnabled = true,
        };

        Computer = new ComputerViewModel(computer);

        computer.Open();
        Update();

        var dispatcher = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        dispatcher.Tick += (_, _) => Update();
        dispatcher.Start();
    }

    public ComputerViewModel Computer { get; }

    private void Update() => Computer.Update(DateTime.Now - Process.GetCurrentProcess().StartTime);
}
