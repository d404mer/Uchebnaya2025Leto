using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class EventCharacteristic
{
    public int EventCharacteristicId { get; set; }

    public int EventId { get; set; }

    public int EventTypeId { get; set; }

    public int EventSectionId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual EventSection EventSection { get; set; } = null!;

    public virtual EventType EventType { get; set; } = null!;
}
