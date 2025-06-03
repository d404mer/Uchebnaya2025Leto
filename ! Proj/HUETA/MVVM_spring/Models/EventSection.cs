using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class EventSection
{
    public int EventSectionId { get; set; }

    public string EventSectionName { get; set; } = null!;

    public virtual ICollection<EventCharacteristic> EventCharacteristics { get; set; } = new List<EventCharacteristic>();

    public virtual ICollection<UserEventSection> UserEventSections { get; set; } = new List<UserEventSection>();
}
