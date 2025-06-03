using System;
using System.Collections.Generic;

namespace StudentXX_prSPR.Models;

public partial class EventType
{
    public long EventTypeId { get; set; }

    public string? EventTypeName { get; set; }

    public virtual ICollection<EventEventType> EventEventTypes { get; set; } = new List<EventEventType>();
}
