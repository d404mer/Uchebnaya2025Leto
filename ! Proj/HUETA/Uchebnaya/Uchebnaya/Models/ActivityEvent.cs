﻿using System;
using System.Collections.Generic;

namespace Uchebnaya.Models;

public partial class ActivityEvent
{
    public long ActivityEventId { get; set; }

    public long? FkActivityId { get; set; }

    public long? FkEventId { get; set; }

    public int? Day { get; set; }

    public DateTime? StartTime { get; set; }

    public long? FkModId { get; set; }

    public virtual Activity? FkActivity { get; set; }

    public virtual Event? FkEvent { get; set; }
}
