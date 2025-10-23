using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class Parameter
{
    public int Id { get; set; }

    public byte PrayerReminderMinutes { get; set; }

    public bool CalculationStrategy { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
