using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string? CityLink { get; set; }

    public virtual ICollection<CityEvent> CityEvents { get; set; } = new List<CityEvent>();
}
