using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentXX_prSPR
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ���������� ������ ���������� ComboBox
            MyComboBox.ItemsSource = new List<string>
            {
                "Option 1",
                "Option 2",
                "Option 3"
            };
        }

        private void OnToggleCalendarClick(object sender, RoutedEventArgs e)
        {
            // ����������� ��������� ���������
            MyCalendar.IsVisible = !MyCalendar.IsVisible;

            // ���� ��������� �����, ��������� ��� �� �������� ����
            if (MyCalendar.IsVisible)
            {
                MyCalendar.ZIndex = 1000;
            }
        }
    }
}