using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class UserEvent
{
    public int UserEventId { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
