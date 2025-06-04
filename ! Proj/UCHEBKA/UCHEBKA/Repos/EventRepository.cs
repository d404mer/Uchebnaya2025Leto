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
        private const string BaseImagePath = "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Events\\"; // Базовый путь к изображениям

        public EventRepository(UchebnayaLeto2025Context db)
        {
            _db = db;
        }

        // Получить все мероприятия с направлениями (+ добавить путь к изображению)
        public List<Event> GetAllEvents()
        {
            var events = _db.Events
                .Include(e => e.SectionEvents)
                .ThenInclude(se => se.FkSec)
                .ToList();

            // Добавляем полный путь к изображению
            foreach (var ev in events)
            {
                //ev.EventLogoUrl = GetFullImagePath(ev.EventLogoUrl);
                ev.EventLogoUrl = "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Events\\1.jpeg";
            }

            return events;
        }

        // Фильтр по направлению (+ добавить путь к изображению)
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

        // Фильтр по дате (+ добавить путь к изображению)
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

        // Метод для формирования полного пути к изображению
        private string GetFullImagePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var fullPath = $"{BaseImagePath}{fileName}";

            // Если файл не найден — возвращаем null (потом обработаем в XAML)
            if (!System.IO.File.Exists(fullPath))
            {
                Console.WriteLine($"Image not found: {fullPath}");
                return null;
            }

            return fullPath;
        }
    }
}