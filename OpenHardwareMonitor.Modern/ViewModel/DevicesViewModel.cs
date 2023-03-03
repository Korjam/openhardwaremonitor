using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class DevicesViewModel : ObservableObject, IMeasurePublisher<ISensor>
{
    private readonly Computer _computer;
    private readonly DispatcherTimer _dispatcher;
    private readonly Axis _xAxis = new()
    {
        Labeler = value => TimeSpan.FromTicks((long)value).ToString(@"hh\:mm"),

        // when using a date time type, let the library know your unit 
        //UnitWidth = TimeSpan.FromMilliseconds(1).Ticks, 

        // if the difference between our points is in hours then we would:
        // UnitWidth = TimeSpan.FromHours(1).Ticks,

        // since all the months and years have a different number of days
        // we can use the average, it would not cause any visible error in the user interface
        // Months: TimeSpan.FromDays(30.4375).Ticks
        // Years: TimeSpan.FromDays(365.25).Ticks

        // The MinStep property forces the separator to be greater than 1 ms.
        //MinStep = TimeSpan.FromMilliseconds(1).Ticks,
    };

    public DevicesViewModel(Computer computer, ISettings settings)
    {
        _computer = computer;
        computer.CPUEnabled = true;
        computer.FanControllerEnabled = true;
        computer.GPUEnabled = true;
        computer.HDDEnabled = true;
        computer.MainboardEnabled = true;
        computer.RAMEnabled = true;

        Computer = new ComputerViewModel(computer, this, settings);

        _dispatcher = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        _dispatcher.Tick += (_, _) => Update();
    }

    public ComputerViewModel Computer { get; }
    public ObservableCollection<PlotViewModel> Plots { get; set; } = new();

    public async Task OpenAsync()
    {
        await _computer.OpenAsync();
        Update();
        _dispatcher.Start();
    }

    public void Publish(ISensor sensor, TimeSpan timestamp)
    {
        var plot = Plots.First(x => x.Title == sensor.SensorType.ToString());
        var series = plot.Series.First(s => s.Name == GetName(sensor));
        var items = (IList<TimeSpanPoint>)series.Values;

        if (items.Count != sensor.Values.Count)
        {
            foreach (var item in sensor.Values.Skip(items.Count))
            {
                items.Add(Convert(item));
            }
        }
        else if (items.Any())
        {
            var lastItem = items.Last();
            var lastValue = Convert(sensor.Values.Last());

            if (lastItem.TimeSpan != lastValue.TimeSpan ||
                lastItem.Value != lastValue.Value)
            {
                items[items.Count - 1] = lastValue;
            }
        }
    }

    public void Register(ISensor sensor)
    {
        var plot = Plots.FirstOrDefault(x => x.Title == sensor.SensorType.ToString());
        if (plot is null)
        {
            plot = new PlotViewModel(_xAxis, sensor.SensorType.ToString());
            Plots.Add(plot);
        }

        plot.Series.Add(new LineSeries<TimeSpanPoint>
        {
            Name = GetName(sensor),
            Values = new ObservableCollection<TimeSpanPoint>(sensor.Values.Select(Convert)),

            //Stroke = new SolidColorPaint(SKColors.AliceBlue, 3),
            Fill = null,
            GeometrySize = 0,

            //LineSmoothness = 0,
        });
    }

    private static TimeSpanPoint Convert(SensorValue x)
    {
        return new TimeSpanPoint(x.Time.ToLocalTime().TimeOfDay, double.IsNaN(x.Value) ? null : x.Value);
    }

    public void Remove(ISensor sensor)
    {
        var plot = Plots.First(x => x.Title == sensor.SensorType.ToString());

        plot.Series.Remove(plot.Series.First(s => s.Name == GetName(sensor)));

        if (!plot.Series.Any())
        {
            Plots.Remove(plot);
        }
    }

    private void Update()
    {
        Computer.Update(DateTime.Now - Process.GetCurrentProcess().StartTime);
    }

    private static string GetName(ISensor sensor)
    {
        return sensor.Hardware.Name + sensor.SensorType + sensor.Name;
    }
}
