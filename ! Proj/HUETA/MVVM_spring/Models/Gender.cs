using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<UserGender> UserGenders { get; set; } = new List<UserGender>();
}
