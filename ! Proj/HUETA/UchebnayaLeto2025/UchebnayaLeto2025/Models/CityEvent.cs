using System;
using System.Collections.Generic;

namespace UchebnayaLeto2025.Models;

public partial class CityEvent
{
    public long CityEventId { get; set; }

    public long? FkEventId { get; set; }

    public long? FkCityId { get; set; }

    public virtual City? FkCity { get; set; }

    public virtual Event? FkEvent { get; set; }
}
