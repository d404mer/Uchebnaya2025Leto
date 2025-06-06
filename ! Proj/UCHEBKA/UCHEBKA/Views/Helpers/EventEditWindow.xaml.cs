using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UCHEBKA.Models;
using UCHEBKA.Repos;

namespace UCHEBKA.Views.Helpers
{
    /// <summary>
    /// Логика взаимодействия для EventEditWindow.xaml
    /// </summary>
    public partial class EventEditWindow : Window
    {
        private readonly EventRepository _eventRepo;
        private Event _currentEvent;
        private bool _isNewEvent;

        public EventEditWindow(Event eventToEdit)
        {
            InitializeComponent();

            var context = new UchebnayaLeto2025Context();
            _eventRepo = new EventRepository(context);

            if (eventToEdit == null)
            {
                _currentEvent = new Event();
                _isNewEvent = true;
                Title = "Создание нового мероприятия";
            }
            else
            {
                _currentEvent = eventToEdit;
                _isNewEvent = false;
                Title = "Редактирование мероприятия";
            }

            LoadEventData();
        }

        private void LoadEventData()
        {
            EventTitleTextBox.Text = _currentEvent.EventTitle;
            EventStartTimePicker.SelectedDate = _currentEvent.EventStartTime;
            EventDurationTextBox.Text = _currentEvent.EventDuration?.ToString();
            EventLogoUrlTextBox.Text = _currentEvent.EventLogoUrl;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Обновление данных мероприятия
                _currentEvent.EventTitle = EventTitleTextBox.Text;
                _currentEvent.EventStartTime = EventStartTimePicker.SelectedDate;

                if (int.TryParse(EventDurationTextBox.Text, out int duration))
                {
                    _currentEvent.EventDuration = duration;
                }
                else
                {
                    _currentEvent.EventDuration = null;
                }

                _currentEvent.EventLogoUrl = EventLogoUrlTextBox.Text;

                // Здесь нужно добавить логику сохранения в базу данных
                // Пока просто закрываем окно с DialogResult = true
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении мероприятия: {ex.Message}",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
