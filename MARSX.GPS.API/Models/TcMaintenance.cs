using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcMaintenance
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public double Start { get; set; }

    public double Period { get; set; }

    public string Attributes { get; set; } = null!;
}
