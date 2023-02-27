using CommunityToolkit.Mvvm.ComponentModel;
using OpenHardwareMonitor.Hardware;
using System;

namespace OpenHardwareMonitor.Modern.ViewModel;

public partial class SensorViewModel : ComponentViewModel
{
    [ObservableProperty]
    private float _value;

    [ObservableProperty]
    private float _min;

    [ObservableProperty]
    private float _max;

    internal readonly ISensor _sensor;

    public SensorViewModel(ISensor sensor) : base(sensor.Name)
    {
        _sensor = sensor;
    }

    public override void Update(TimeSpan timestamp)
    {
        Value = _sensor.Value ?? 0;

        if (_sensor.Min != null)
        {
            Min = (float)_sensor.Min;
        }

        if (_sensor.Max != null)
        {
            Max = (float)_sensor.Max;
        }

        base.Update(timestamp);
    }
}
