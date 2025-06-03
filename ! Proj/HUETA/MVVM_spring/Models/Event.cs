using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public int? EventLength { get; set; }

    //public string ImagePath { get; set; } = string.Empty;

    public virtual ICollection<CityEvent> CityEvents { get; set; } = new List<CityEvent>();

    public virtual ICollection<EventActivity> EventActivities { get; set; } = new List<EventActivity>();

    public virtual ICollection<EventCharacteristic> EventCharacteristics { get; set; } = new List<EventCharacteristic>();

    public virtual ICollection<EventJudge> EventJudges { get; set; } = new List<EventJudge>();

    public virtual ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
}
