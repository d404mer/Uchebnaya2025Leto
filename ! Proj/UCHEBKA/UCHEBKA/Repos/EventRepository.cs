using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UCHEBKA.Models;

namespace UCHEBKA.Repos
{
    public class EventRepository
    {
        private readonly UchebnayaLeto2025Context _db;
        private const string BaseImagePath = "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Events\\";

        public EventRepository(UchebnayaLeto2025Context db)
        {
            _db = db;
        }

        public List<Event> GetAllEvents()
        {
            var events = _db.Events
                .Include(e => e.SectionEvents)
                .ThenInclude(se => se.FkSec)
                .ToList();

            foreach (var ev in events)
            {
                ev.EventLogoUrl = GetFullImagePath(ev.EventLogoUrl);
            }

            return events;
        }

        public List<Event> GetEventsBySection(int sectionId)
        {
            var events = _db.Events
                .Where(e => e.SectionEvents.Any(se => se.FkSec.SecId == sectionId))
                .ToList();

            foreach (var ev in events)
            {
                ev.EventLogoUrl = GetFullImagePath(ev.EventLogoUrl);
            }

            return events;
        }

        public List<Event> GetEventsByDate(DateTime? date)
        {
            if (!date.HasValue)
                return new List<Event>();

            var events = _db.Events
                .Include(e => e.SectionEvents)
                    .ThenInclude(se => se.FkSec)
                .Where(e => e.EventStartTime.HasValue &&
                            e.EventStartTime.Value.Date == date.Value.Date)
                .ToList();

            foreach (var ev in events)
            {
                ev.EventLogoUrl = GetFullImagePath(ev.EventLogoUrl);
            }

            return events;
        }

        private string GetFullImagePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Events\\2.jpeg";

            var fullPath = $"{BaseImagePath}{fileName}";

            if (!System.IO.File.Exists(fullPath))
            {
                Console.WriteLine($"Image not found: {fullPath}");
                //return "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Events\\no pic.png";
            }

            return fullPath;
        }

        public void AddEvent(Event newEvent)
        {
            _db.Events.Add(newEvent);
            _db.SaveChanges();
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            _db.Events.Update(eventToUpdate);
            _db.SaveChanges();
        }
        public long GetNextEventId()
        {
            return _db.Events.Any() ? _db.Events.Max(e => e.EventId) + 1 : 1;
        }

        public bool DeleteEvent(long eventId)
        {
            try
            {
                var eventToDelete = _db.Events.Find(eventId);
                if (eventToDelete != null)
                {
                    _db.ActivityEvents.RemoveRange(_db.ActivityEvents.Where(ae => ae.FkEventId == eventId));
                    _db.SectionEvents.RemoveRange(_db.SectionEvents.Where(se => se.FkEventId == eventId));

                    _db.Events.Remove(eventToDelete);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка при удалении мероприятия: {ex.Message}");
                return false;
            }
        }
    }
}