using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using UCHEBKA.Views;

namespace UCHEBKA
{
    public partial class MainWindow : Window
    {
        private readonly EventRepository _eventRepo;
        private readonly SectionRepository _sectionRepo;
        private List<Event> _allEvents;
        private DateTime? _selectedDate = null;
        private int? _selectedSectionId = null;

        public MainWindow()
        {
            var db = new UchebnayaLeto2025Context();
            _eventRepo = new EventRepository(db);
            _sectionRepo = new SectionRepository(db);

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _allEvents = _eventRepo.GetAllEvents();
            var sections = _sectionRepo.GetAllSections();

            // Добавляем пустой элемент для сброса фильтра
            var allSections = new List<Section> { new Section { SecId = 0, SecName = "Все секции" } };
            allSections.AddRange(sections);

            MyComboBox.ItemsSource = allSections;
            MyComboBox.SelectedIndex = 0;

            ShowEvents(_allEvents);
        }

        private void ShowEvents(List<Event> events)
        {
            EventsWrapPanel.Children.Clear();
            foreach (var ev in events)
            {
                EventsWrapPanel.Children.Add(new EventCard(ev));
            }
        }

        private void ApplyFilters()
        {
            List<Event> filteredEvents;

            // Если выбраны и дата и секция
            if (_selectedDate.HasValue && _selectedSectionId.HasValue && _selectedSectionId > 0)
            {
                // Получаем события по секции
                var eventsBySection = _eventRepo.GetEventsBySection(_selectedSectionId.Value);
                // Получаем события по дате
                var eventsByDate = _eventRepo.GetEventsByDate(_selectedDate);
                // Находим пересечение
                filteredEvents = eventsBySection.Intersect(eventsByDate).ToList();
            }
            // Если выбрана только дата
            else if (_selectedDate.HasValue)
            {
                filteredEvents = _eventRepo.GetEventsByDate(_selectedDate);
            }
            // Если выбрана только секция
            else if (_selectedSectionId.HasValue && _selectedSectionId > 0)
            {
                filteredEvents = _eventRepo.GetEventsBySection(_selectedSectionId.Value);
            }
            // Если фильтры не выбраны
            else
            {
                filteredEvents = _allEvents;
            }

            ShowEvents(filteredEvents);
        }

        private void DatePickerButton_Click(object sender, RoutedEventArgs e)
        {
            MyCalendar.Visibility = MyCalendar.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedDate = MyCalendar.SelectedDate;
            MyCalendar.Visibility = Visibility.Collapsed;

            if (_selectedDate.HasValue)
            {
                SelectedDateText.Text = $"Выбранная дата: {_selectedDate.Value.ToShortDateString()}";
            }
            else
            {
                SelectedDateText.Text = string.Empty;
            }

            ApplyFilters();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyComboBox.SelectedValue != null && int.TryParse(MyComboBox.SelectedValue.ToString(), out int sectionId))
            {
                _selectedSectionId = sectionId > 0 ? sectionId : null;
                ApplyFilters();
            }
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            _selectedDate = null;
            _selectedSectionId = null;
            MyComboBox.SelectedIndex = 0;
            SelectedDateText.Text = string.Empty;
            MyCalendar.SelectedDate = null;
            ShowEvents(_allEvents);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Close();
        }
    }
}