using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_spring.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVM_spring.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly PrImportContext _db = new PrImportContext();

        [ObservableProperty]
        private ObservableCollection<Event> _events = new();

        [ObservableProperty]
        private ObservableCollection<EventSection> _eventSections = new();

        [ObservableProperty]
        private EventSection? _selectedEventSection;

        [ObservableProperty]
        private DateTime? _selectedDate;

        public MainWindowViewModel()
        {
            LoadEvents();
            LoadEventSection();
        }

        string ImagePath;

        private void LoadEvents()
        {
            var events = _db.Events.ToList();

            
            foreach (var e in events)
            {
                ImagePath = System.IO.File.Exists($"Assets/EventsLogo/{e.EventId}.jpg")
        ? $"/Assets/EventsLogo/{e.EventId}.jpg"
        : "/Assets/EventsLogo/11.jpg";
            }

            Events = new ObservableCollection<Event>(events);
        }

        private void LoadEventSection()
        {
            var sections = _db.EventSections.ToList();
            EventSections = new ObservableCollection<EventSection>(sections);
        }


        [RelayCommand]
        private void ApplyFilter()
        {
            var filtered = _db.Events.AsQueryable();

            if (SelectedEventSection != null)
            {
                filtered = filtered.Where(e => e.EventCharacteristics.Any(ec => ec.EventSectionId == SelectedEventSection.EventSectionId));
            }

            if (SelectedDate != null)
            {
                var date = SelectedDate.Value.Date;
                filtered = filtered.Where(e => e.EventDate.Date == date);
            }

            var filteredList = filtered.ToList();

            

            Events = new ObservableCollection<Event>(filteredList);
        }
    }
}