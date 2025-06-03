using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using StudentXX_prSPR.Models;
namespace StudentXX_prSPR.Models.UchebnayaLeto2025Context;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Event> Events { get; } = new();

    public MainWindowViewModel()
    {
        LoadEventsAsync();
    }

    private async Task LoadEventsAsync()
    {
        using (var db = new UchebnayaLeto2025Context())
        {
            var events = await db.Events.ToListAsync();
            // UI-обновление должно быть на UI-потоке
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                Events.Clear();
                foreach (var ev in events)
                    Events.Add(ev);
            });
        }
    }
}
