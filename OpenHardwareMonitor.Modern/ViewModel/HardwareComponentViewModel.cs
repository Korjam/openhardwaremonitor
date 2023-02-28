using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
using System;
using System.Linq;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class HardwareComponentViewModel : ComponentViewModel
{
    internal readonly IHardware _hardware;
    private readonly IMeasurePublisher<ISensor> _receiver;

    public HardwareComponentViewModel(IHardware hardware, IMeasurePublisher<ISensor> receiver) : base(hardware.Name)
    {
        _hardware = hardware;
        _receiver = receiver;

        foreach (var item in hardware.SubHardware)
        {
            Components.Add(new HardwareComponentViewModel(item, receiver));
        }

        foreach (var item in hardware.Sensors.GroupBy(x => x.SensorType))
        {
            var group = FindGroup(item.Key);

            foreach (var sensor in item)
            {
                group.Components.Add(new SensorViewModel(sensor, receiver));
            }
        }

        hardware.SensorAdded += Hardware_SensorAdded;
        hardware.SensorRemoved += Hardware_SensorRemoved;
    }

    private void Hardware_SensorAdded(ISensor sensor)
    {
        var group = FindGroup(sensor.SensorType);
        group.Components.Add(new SensorViewModel(sensor, _receiver));
    }

    private void Hardware_SensorRemoved(ISensor sensor)
    {
        var target = FindGroup(sensor.SensorType).Components.OfType<SensorViewModel>().FirstOrDefault(x => x._sensor == sensor);

        if (target is not null)
        {
            Components.Remove(target);
        }
    }

    private ComponentViewModel FindGroup(SensorType key)
    {
        var group = Components.FirstOrDefault(x => x.Name == key.ToString());

        if (group is null)
        {
            group = new ComponentViewModel(key.ToString());
            Components.Add(group);
        }

        return group;
    }

    public override void Update(TimeSpan timestamp)
    {
        _hardware.Update();
        base.Update(timestamp);
    }
}
