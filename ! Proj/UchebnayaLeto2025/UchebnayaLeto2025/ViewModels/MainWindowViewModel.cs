using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UchebnayaLeto2025;
using UchebnayaLeto2025.Models;
using UchebnayaLeto2025.ViewModels;


public class MainWindowViewModel : ViewModelBase
{

    private readonly UchebnayaLeto2025Context _context;
    public ObservableCollection<EventViewModel> Events { get; } = new();

    public MainWindowViewModel() {
        _context = new UchebnayaLeto2025Context();
        LoadEvents();
    }

    private void LoadEvents()
    {
        var eventsWithSections = _context.Events
            .Include(e => e.SectionEvents)
                .ThenInclude(se => se.FkSec)
            .ToList();

        Events.Clear();

        foreach (var ev in eventsWithSections)
        {
            var direction = ev.SectionEvents.FirstOrDefault()?.FkSec?.SecName ?? "Без направления";

            Events.Add(new EventViewModel
            {
                Title = ev.EventTitle,
                StartTime = ev.EventStartTime,
                Direction = direction
            });
        }
    }
}
