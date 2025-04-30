using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserReport
{
    public int Userid { get; set; }

    public int Reportid { get; set; }

    public virtual TcReport Report { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
