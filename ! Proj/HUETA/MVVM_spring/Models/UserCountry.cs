using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class UserCountry
{
    public int UserCountryId { get; set; }

    public int UserId { get; set; }

    public int CountryCodeNumber { get; set; }

    public virtual Country CountryCodeNumberNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
