using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class PrayerReminder
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Datetime { get; set; }
}
