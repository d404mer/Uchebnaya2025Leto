using System;
using System.Collections.Generic;

namespace StudentXX_prSPR.Models;

public partial class UserSec
{
    public long UserSecId { get; set; }

    public long? FkUserId { get; set; }

    public long? FkSecId { get; set; }

    public virtual Section? FkSec { get; set; }

    public virtual User? FkUser { get; set; }
}
