using System;
using System.Collections.Generic;

namespace UchebnayaLeto2025.Models;

public partial class UserSex
{
    public long UserSecId { get; set; }

    public long? FkUserId { get; set; }

    public long? FkSexId { get; set; }

    public virtual Sex? FkSex { get; set; }

    public virtual User? FkUser { get; set; }
}
