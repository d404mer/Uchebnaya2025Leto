using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Uchebnaya.Models;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace Uchebnaya.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly UchebnayaLeto2025Context _db = new UchebnayaLeto2025Context();


        // Коллекция мероприятий для отображения
        public ObservableCollection<Event> Events { get; } = new();

        // Выбранное направление для фильтрации
        private Section? _selectedSection;
        public Section? SelectedSection
        {
            get => _selectedSection;
            set => this.RaiseAndSetIfChanged(ref _selectedSection, value);
        }

    }
}
