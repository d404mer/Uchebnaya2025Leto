using System;
using System.Collections.Generic;

namespace StudentXX_prSPR.Models;

public partial class UserEvent
{
    public long UserEventId { get; set; }

    public long? FkUserId { get; set; }

    public long? FkEventId { get; set; }

    public virtual Event? FkEvent { get; set; }

    public virtual User? FkUser { get; set; }
}
