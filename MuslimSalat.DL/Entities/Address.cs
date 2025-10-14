using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int PostCode { get; set; }

    public string? Locality { get; set; }

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
