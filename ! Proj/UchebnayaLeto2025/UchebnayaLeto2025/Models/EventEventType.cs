using System;
using System.Collections.Generic;

namespace UchebnayaLeto2025.Models;

public partial class EventEventType
{
    public long EventEvenTypeId { get; set; }

    public long? FkEventId { get; set; }

    public long? FkEvenTypeId { get; set; }

    public virtual EventType? FkEvenType { get; set; }

    public virtual Event? FkEvent { get; set; }
}
