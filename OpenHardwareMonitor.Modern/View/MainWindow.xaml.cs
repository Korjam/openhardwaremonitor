using OpenHardwareMonitor.Modern.ViewModel;
using System.Windows;

namespace OpenHardwareMonitor.Modern.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainViewModel ViewModel => (MainViewModel)DataContext;

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await ViewModel.OpenAsync();
    }
}