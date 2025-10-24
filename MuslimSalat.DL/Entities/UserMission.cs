using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class UserMission
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdMission { get; set; }

    public DateTime? CompletedDatetime { get; set; }

    public virtual Mission IdMissionNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
