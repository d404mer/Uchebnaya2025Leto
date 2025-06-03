using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityName { get; set; } = null!;

    public int? ActivityMark { get; set; }

    public virtual ICollection<EventActivity> EventActivities { get; set; } = new List<EventActivity>();

    public virtual ICollection<EventJudge> EventJudges { get; set; } = new List<EventJudge>();
}
