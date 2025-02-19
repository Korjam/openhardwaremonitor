using CommunityToolkit.Mvvm.ComponentModel;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Modern.Abstractions;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class MainViewModel : ObservableObject, IMeasurePublisher<ISensor>
{
    private readonly Computer _computer;
    private readonly DispatcherTimer _dispatcher;

    public MainViewModel(Computer computer, ISettings settings)
    {
        _computer = computer;
        computer.CPUEnabled = true;
        computer.FanControllerEnabled = true;
        computer.GPUEnabled = true;
        computer.HDDEnabled = true;
        computer.MainboardEnabled = true;
        computer.RAMEnabled = true;

        PlotModel = CreateModel();

        Computer = new ComputerViewModel(computer, this, settings);

        _dispatcher = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        _dispatcher.Tick += (_, _) => Update();
    }

    public ComputerViewModel Computer { get; }

    public PlotModel PlotModel { get; set; }

    public async Task OpenAsync()
    {
        await _computer.OpenAsync();
        Update();
        _dispatcher.Start();
    }

    public void Publish(ISensor sensor, TimeSpan timestamp)
    {
        var name = GetName(sensor);
        var series = PlotModel.Series
            .OfType<LineSeries>()
            .First(x => x.Title == name);

        var items = (IList<Item>)series.ItemsSource;

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

            if (lastItem.X != lastValue.X ||
                lastItem.Y != lastValue.Y)
            {
                items[items.Count - 1] = lastValue;
            }
        }
    }

    public void Register(ISensor sensor)
    {
        if (!PlotModel.Axes.Any(x => x.Title == sensor.SensorType.ToString()))
        {
            PlotModel.Axes.Add(new LinearAxis
            {
                Key = sensor.SensorType.ToString(),
                Title = sensor.SensorType.ToString(),
                Position = AxisPosition.Left,
                ExtraGridlineStyle = LineStyle.Solid,
                AxislineStyle = LineStyle.Solid,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid
            });

            CalculatePositions();
        }

        var name = GetName(sensor);
        var series = PlotModel.Series
            .OfType<LineSeries>()
            .FirstOrDefault(x => x.Title == name);

        if (series is null)
        {
            series = new LineSeries
            {
                Title = name,
                StrokeThickness = 1,
                ItemsSource = new ObservableCollection<Item>(sensor.Values.Select(Convert)),
                YAxisKey = sensor.SensorType.ToString(),
                DataFieldX = "X",
                DataFieldY = "Y"
            };
            PlotModel.Series.Add(series);
        }

        PlotModel.InvalidatePlot(false);
    }

    public void Remove(ISensor sensor)
    {
        var name = GetName(sensor);
        var series = PlotModel.Series
            .OfType<LineSeries>()
            .FirstOrDefault(x => x.Title == name);

        if (series is not null)
        {
            PlotModel.Series.Remove(series);
        }

        if (!PlotModel.Series.OfType<LineSeries>().Any(x => x.YAxisKey == sensor.SensorType.ToString()))
        {
            var axis = PlotModel.Axes.FirstOrDefault(x => x.Title == sensor.SensorType.ToString());

            if (axis is not null)
            {
                PlotModel.Axes.Remove(axis);
                CalculatePositions();
            }
        }

        PlotModel.InvalidatePlot(false);
    }

    private void CalculatePositions()
    {
        var axes = PlotModel.Axes.Where(x => x.Position == AxisPosition.Left)
            .OrderBy(x => x.Title)
            .ToList();

        for (int i = 0; i < axes.Count; i++)
        {
            var axis = axes[i];
            axis.StartPosition = (double)i / axes.Count;
            axis.EndPosition = (double)(i + 1) / axes.Count;
        }
    }

    private void Update()
    {
        Computer.Update(DateTime.Now - Process.GetCurrentProcess().StartTime);
        PlotModel.InvalidatePlot(true);
    }

    private static string GetName(ISensor sensor)
    {
        return sensor.Hardware.Name + sensor.SensorType + sensor.Name;
    }

    private static PlotModel CreateModel()
    {
        var model = new PlotModel();
        model.Padding = new OxyThickness(8, 0, 0, 8);
        model.Axes.Add(new TimeSpanAxis
        {
            Position = AxisPosition.Bottom,
            ExtraGridlineStyle = LineStyle.Solid,
            AxislineStyle = LineStyle.Solid,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Solid,
        });
        model.Annotations.Add(new DelegateAnnotation(render =>
        {
            var pen = new OxyPen(OxyColors.Black, 1, LineStyle.Solid);
            foreach (var axis in model.Axes.Where(x => x.IsVertical()))
            {
                double startPosition = model.PlotArea.Left;
                double endPosition = model.PlotArea.Right;

                double line1Y = axis.Transform(axis.ClipMinimum);
                double line2Y = axis.Transform(axis.ClipMaximum);

                render.DrawLine(
                    startPosition, line1Y,
                    endPosition,   line1Y,
                    pen, EdgeRenderingMode.Automatic);

                render.DrawLine(
                    startPosition, line2Y,
                    endPosition,   line2Y,
                    pen, EdgeRenderingMode.Automatic);
            }
        }));

        return model;
    }

    private static Item Convert(SensorValue x) =>
        new()
        {
            X = x.Time.ToLocalTime() - Process.GetCurrentProcess().StartTime,
            Y = x.Value
        };
}

public class Item
{
    public TimeSpan X { get; set; }
    public double Y { get; set; }
}
