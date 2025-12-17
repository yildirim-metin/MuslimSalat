using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdUserResponsible { get; set; }

    public virtual ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();

    public virtual User IdUserResponsibleNavigation { get; set; } = null!;
}
