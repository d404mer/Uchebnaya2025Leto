using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class UserEventSection
{
    public int UserEventSectionId { get; set; }

    public int UserId { get; set; }

    public int EventSectionId { get; set; }

    public virtual EventSection EventSection { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
