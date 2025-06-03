using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string EventTypeName { get; set; } = null!;

    public virtual ICollection<EventCharacteristic> EventCharacteristics { get; set; } = new List<EventCharacteristic>();
}
