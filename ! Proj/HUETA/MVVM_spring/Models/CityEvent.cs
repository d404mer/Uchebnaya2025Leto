using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class CityEvent
{
    public int CityEventId { get; set; }

    public int CityId { get; set; }

    public int EventId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
