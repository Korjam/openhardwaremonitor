using CommunityToolkit.Mvvm.ComponentModel;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
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

    [ObservableProperty]
    private bool _publish;

    internal readonly ISensor _sensor;
    private readonly IMeasurePublisher<ISensor> _receiver;
    private readonly ISettings _settings;

    public SensorViewModel(ISensor sensor, IMeasurePublisher<ISensor> receiver, ISettings settings) : base(sensor.Name)
    {
        _sensor = sensor;
        _receiver = receiver;
        _settings = settings;

        Publish = bool.Parse(settings.GetValue($"{_sensor.Identifier}/plot", "false"));
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

        if (Publish)
        {
            _receiver.Publish(_sensor, timestamp);
        }

        base.Update(timestamp);
    }

    partial void OnPublishChanged(bool value)
    {
        _settings.SetValue($"{_sensor.Identifier}/plot", value.ToString());

        if (value)
        {
            _receiver.Register(_sensor);
        }
        else
        {
            _receiver.Remove(_sensor);
        }
    }
}
