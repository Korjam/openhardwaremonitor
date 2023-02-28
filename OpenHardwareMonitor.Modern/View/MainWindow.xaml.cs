using Microsoft.Extensions.DependencyInjection;
using OpenHardwareMonitor.Modern.ViewModel;
using System;
using Wpf.Ui.Appearance;
using Wpf.Ui.Contracts;
using Wpf.Ui.Controls.Navigation;

namespace OpenHardwareMonitor.Modern.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : INavigationWindow
{
    private readonly IThemeService _themeService;

    public MainWindow(MainViewModel mainViewModel,
        INavigationService navigationService,
        IPageService pageService,
        IThemeService themeService,
        ISnackbarService snackbarService,
        IDialogService contentDialogService)
    {
        Watcher.Watch(this);

        _themeService = themeService;

        InitializeComponent();

        DataContext = mainViewModel;

        // We define a page provider for navigation
        SetPageService(pageService);

        snackbarService.SetSnackbarControl(Snackbar);
        navigationService.SetNavigationControl(NavigationView);
        contentDialogService.SetDialogControl(ContentDialog);

        //NavigationView.SetServiceProvider(serviceProvider);
        //NavigationView.Loaded += (_, _) => NavigationView.Navigate(typeof(DashboardPage));
    }

    public INavigationView GetNavigation() =>
        NavigationView;

    public bool Navigate(Type pageType) =>
        NavigationView.Navigate(pageType);

    public void SetPageService(IPageService pageService) =>
        NavigationView.SetPageService(pageService);

    public void ShowWindow() =>
        Show();

    public void CloseWindow() =>
        Close();

    private void NavigationButtonTheme_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        _themeService.SetTheme(_themeService.GetTheme() == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark);
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }
}