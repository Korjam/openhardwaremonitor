using OpenHardwareMonitor.Modern.ViewModel;
using System.Windows;
using Wpf.Ui.Controls.Navigation;

namespace OpenHardwareMonitor.Modern.View.Pages;

/// <summary>
/// Interaction logic for DevicesPage.xaml
/// </summary>
public partial class DevicesPage : INavigableView<DevicesViewModel>
{
    public DevicesPage(DevicesViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }

    public DevicesViewModel ViewModel => (DevicesViewModel)DataContext;

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await ViewModel.OpenAsync();
    }
}
