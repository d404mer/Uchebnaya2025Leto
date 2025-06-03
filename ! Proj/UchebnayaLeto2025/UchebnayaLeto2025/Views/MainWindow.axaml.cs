using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace UchebnayaLeto2025.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();

        MyComboBox.ItemsSource = new List<string>
            {
                "Option 1",
                "Option 2",
                "Option 3"
            };
    }

    private void OnToggleCalendarClick(object sender, RoutedEventArgs e)
    {
        MyCalendar.IsVisible = !MyCalendar.IsVisible;

        if (MyCalendar.IsVisible)
        {
            MyCalendar.ZIndex = 1000;
        }
    }
}