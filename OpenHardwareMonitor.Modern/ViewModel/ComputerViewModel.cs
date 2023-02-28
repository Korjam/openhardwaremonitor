using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
using System;
using System.Linq;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class ComputerViewModel : ComponentViewModel
{
    private readonly IMeasurePublisher<ISensor> _receiver;
    private readonly ISettings _settings;

    public ComputerViewModel(IComputer computer, IMeasurePublisher<ISensor> receiver, ISettings settings) : base(Environment.MachineName)
    {
        _receiver = receiver;
        _settings = settings;

        foreach (var item in computer.Hardware)
        {
            Components.Add(new HardwareComponentViewModel(item, receiver, settings));
        }

        computer.HardwareAdded += Computer_HardwareAdded;
        computer.HardwareRemoved += Computer_HardwareRemoved;
    }

    private void Computer_HardwareAdded(IHardware hardware)
    {
        Components.Add(new HardwareComponentViewModel(hardware, _receiver, _settings));
    }

    private void Computer_HardwareRemoved(IHardware hardware)
    {
        var target = Components.OfType<HardwareComponentViewModel>().FirstOrDefault(x => x._hardware == hardware);

        if (target is not null)
        {
            Components.Remove(target);
        }
    }
}