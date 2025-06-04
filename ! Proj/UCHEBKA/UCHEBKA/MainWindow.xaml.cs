using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using UCHEBKA.Views;
using Section = UCHEBKA.Models.Section;

namespace UCHEBKA
{

    public partial class MainWindow : Window
    {
        private readonly EventRepository _eventRepo;
        private readonly SectionRepository _sectionRepo;
        private List<Event> _events;



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
            // Загружаем данные через репозитории
            _events = _eventRepo.GetAllEvents();
            var sections = _sectionRepo.GetAllSections();

            MyComboBox.ItemsSource = sections;
            MyComboBox.DisplayMemberPath = "SecName";

            ShowEvents(_events);
        }


        private void ShowEvents(List<Event> events)
        {
            EventsWrapPanel.Children.Clear();
            foreach (var ev in events)
            {
                EventsWrapPanel.Children.Add(new EventCard(ev));
            }
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            //// Явно указываем пространство имён, чтобы избежать конфликта с System.Windows.Documents.Section
            //if (MyComboBox.SelectedItem is UCHEBKA.Models.Section selectedSection)
            //{
            //    // Теперь метод принимает long, и SecId можно передавать напрямую
            //    var filteredEvents = _eventRepo.GetEventsBySection(selectedSection.SecId);
            //    ShowEvents(filteredEvents);
            //}
            //else
            //{
            //    // Если ничего не выбрано, показываем все мероприятия
            //    ShowEvents(_events);
            //}
        }

        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyCalendar.SelectedDate is DateTime date)
            {
                var filteredEvents = _eventRepo.GetEventsByDate(date);
                ShowEvents(filteredEvents);
            }
        }
    }
}