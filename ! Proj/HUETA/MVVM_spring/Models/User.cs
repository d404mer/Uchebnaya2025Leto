using System;
using System.Collections.Generic;

namespace MVVM_spring.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public DateOnly? UserDateOfBirth { get; set; }

    public string? UserPhoneNumber { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserFoto { get; set; } = null!;

    public string? UserLastName { get; set; }

    public virtual ICollection<EventActivity> EventActivities { get; set; } = new List<EventActivity>();

    public virtual ICollection<EventJudge> EventJudges { get; set; } = new List<EventJudge>();

    public virtual ICollection<UserCountry> UserCountries { get; set; } = new List<UserCountry>();

    public virtual ICollection<UserEventSection> UserEventSections { get; set; } = new List<UserEventSection>();

    public virtual ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();

    public virtual ICollection<UserGender> UserGenders { get; set; } = new List<UserGender>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
