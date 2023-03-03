using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using OpenHardwareMonitor.Modern.ViewModel;
using System;
using System.Windows.Controls;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

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
        IThemeService themeService)
    {
        Watcher.Watch(this);

        _themeService = themeService;

        InitializeComponent();

        DataContext = mainViewModel;

        // We define a page provider for navigation
        SetPageService(pageService);

        // If you want to use INavigationService instead of INavigationWindow you can define its navigation here.
        navigationService.SetNavigationControl(RootNavigation);

        // Allows you to use the Snackbar control defined in this window in other pages or windows
        //snackbarService.SetSnackbarControl(RootSnackbar);

        // Allows you to use the Dialog control defined in this window in other pages or windows
        //dialogService.SetDialogControl(RootDialog);
    }

    public Frame GetFrame()
        => RootFrame;

    public INavigation GetNavigation()
        => RootNavigation;

    public bool Navigate(Type pageType)
        => RootNavigation.Navigate(pageType);

    public void SetPageService(IPageService pageService)
        => RootNavigation.PageService = pageService;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();

    private void NavigationButtonTheme_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        var theme = _themeService.GetTheme() == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark;
        LiveCharts.Configure(config =>
        {
            switch (theme)
            {
                case ThemeType.Unknown:
                    break;
                case ThemeType.Dark:
                    config.AddDarkTheme();
                    break;
                case ThemeType.Light:
                    config.AddLightTheme();
                    break;
                case ThemeType.HighContrast:
                    break;
                default:
                    break;
            }
        });
        _themeService.SetTheme(theme);
    }
}