using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class TempUser
{
    public int UserId { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public DateOnly? UserDateOfBirth { get; set; }

    public string? UserPhoneNumber { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserFoto { get; set; } = null!;
}
