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

    public virtual Address? IdAddressNavigation { get; set; }
}
