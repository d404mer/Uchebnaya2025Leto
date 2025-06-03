using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class Country
{
    public string? CountryCodeChar { get; set; }

    public int CountryCodeNumber { get; set; }

    public string CountryNameRu { get; set; } = null!;

    public string CountryNameEng { get; set; } = null!;

    public virtual ICollection<UserCountry> UserCountries { get; set; } = new List<UserCountry>();
}
