using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UCHEBKA.Repos
{
    class EventRepository
    {
        private readonly UchebnayaLeto2025Context _db;

        public EventRepository(UchebnayaLeto2025Context db)
        {
            _db = db;
        }
        // Получить все мероприятия с направлениями
        public List<Event> GetAllEvents()
        {
            return _db.Events
                .Include(e => e.SectionEvents)
                .ThenInclude(se => se.FkSec)
                .ToList();
        }

        // Фильтр по направлению
        public List<Event> GetEventsBySection(int sectionId)
        {
            return _db.Events
                .Where(e => e.SectionEvents.Any(se => se.FkSec.SecId == sectionId))
                .ToList();
        }

        // Фильтр по дате
        public List<Event> GetEventsByDate(DateTime? date)
        {
            if (!date.HasValue)
                return new List<Event>();

            return _db.Events
                .Include(e => e.SectionEvents)
                    .ThenInclude(se => se.FkSec)
                .Where(e => e.EventStartTime.HasValue &&
                            e.EventStartTime.Value.Date == date.Value.Date)
                .ToList();
        }
    }
}
