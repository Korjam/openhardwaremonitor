using OpenHardwareMonitor.Hardware;
using System;
using System.Linq;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class ComputerViewModel : ComponentViewModel
{
    public ComputerViewModel(IComputer computer) : base(Environment.MachineName)
    {
        foreach (var item in computer.Hardware)
        {
            Components.Add(new HardwareComponentViewModel(item));
        }

        computer.HardwareAdded += Computer_HardwareAdded;
        computer.HardwareRemoved += Computer_HardwareRemoved;
    }

    private void Computer_HardwareAdded(IHardware hardware)
    {
        Components.Add(new HardwareComponentViewModel(hardware));
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