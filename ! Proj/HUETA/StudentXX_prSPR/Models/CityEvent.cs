﻿using System;
using System.Collections.Generic;

namespace StudentXX_prSPR.Models;

public partial class CityEvent
{
    public long CityEventId { get; set; }

    public long? FkEventId { get; set; }

    public long? FkCityId { get; set; }

    public virtual City? FkCity { get; set; }

    public virtual Event? FkEvent { get; set; }
}
