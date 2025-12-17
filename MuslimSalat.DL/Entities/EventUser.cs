using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class EventUser
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdEvent { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
