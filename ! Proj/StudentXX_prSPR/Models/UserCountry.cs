using System;
using System.Collections.Generic;

namespace StudentXX_prSPR.Models;

public partial class UserCountry
{
    public long UserCountryId { get; set; }

    public long? FkUserId { get; set; }

    public long? FkCountryId { get; set; }

    public virtual Country? FkCountry { get; set; }

    public virtual User? FkUser { get; set; }
}
