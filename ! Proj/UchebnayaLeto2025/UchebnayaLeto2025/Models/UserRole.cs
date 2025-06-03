using System;
using System.Collections.Generic;

namespace UchebnayaLeto2025.Models;

public partial class UserRole
{
    public long UserRoleId { get; set; }

    public long? FkUserId { get; set; }

    public long? FkRoleId { get; set; }

    public virtual Role? FkRole { get; set; }

    public virtual User? FkUser { get; set; }
}
