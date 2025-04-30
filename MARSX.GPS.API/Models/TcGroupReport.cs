using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcGroupReport
{
    public int Groupid { get; set; }

    public int Reportid { get; set; }

    public virtual TcGroup Group { get; set; } = null!;

    public virtual TcReport Report { get; set; } = null!;
}
