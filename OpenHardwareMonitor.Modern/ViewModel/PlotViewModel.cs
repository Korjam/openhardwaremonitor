using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;

namespace OpenHardwareMonitor.Modern.ViewModel;

public partial class PlotViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title;

    public ObservableCollection<ISeries> Series { get; set; } = new();

    public Axis[] XAxes { get; }
    public Axis[] YAxes { get; }

    public PlotViewModel(Axis xaxis, string name)
    {
        XAxes = new[]
        {
            xaxis
        };
        YAxes = new[]
        {
            new Axis
            {
                Name = name
            }
        };

        _title = name;
    }
}