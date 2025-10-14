using System;
using System.Collections.Generic;

namespace MuslimSalat.DL.Entities;

public partial class Mission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Level { get; set; } = null!;
}
