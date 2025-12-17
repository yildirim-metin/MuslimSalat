using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string Role { get; set; } = null!;

    public int? IdAddress { get; set; }

    public virtual ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Address? IdAddressNavigation { get; set; }

    public virtual Parameter? Parameter { get; set; }

    public virtual ICollection<UserMission> UserMissions { get; set; } = new List<UserMission>();
}
