using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class UserGender
{
    public int UserGenderId { get; set; }

    public int UserId { get; set; }

    public int GenderId { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
