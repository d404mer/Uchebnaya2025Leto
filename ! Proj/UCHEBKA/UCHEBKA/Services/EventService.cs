using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCHEBKA.Models;

namespace UCHEBKA.Services
{
    class EventService
    {
        private readonly UchebnayaLeto2025Context _db;

        public EventService(UchebnayaLeto2025Context db)
        {
            _db = db;
        }

        public List<Event> GetEventsWithSections()
        {
            return _db.Events
                .Include(e => e.SectionEvents)
                .ThenInclude(se => se.FkSec)
                .ToList();
        }
    }
}
