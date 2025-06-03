using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class EventJudge
{
    public int EventJudgeId { get; set; }

    public int EventId { get; set; }

    public int ActivityId { get; set; }

    public int UserId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
