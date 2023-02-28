using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
using System;
using System.Linq;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class ComputerViewModel : ComponentViewModel
{
    private readonly IMeasurePublisher<ISensor> _receiver;

    public ComputerViewModel(IComputer computer, IMeasurePublisher<ISensor> receiver) : base(Environment.MachineName)
    {
        _receiver = receiver;

        foreach (var item in computer.Hardware)
        {
            Components.Add(new HardwareComponentViewModel(item, receiver));
        }

        computer.HardwareAdded += Computer_HardwareAdded;
        computer.HardwareRemoved += Computer_HardwareRemoved;
    }

    private void Computer_HardwareAdded(IHardware hardware)
    {
        Components.Add(new HardwareComponentViewModel(hardware, _receiver));
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