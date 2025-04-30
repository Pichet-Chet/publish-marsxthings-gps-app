using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDeviceReport
{
    public int Deviceid { get; set; }

    public int Reportid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcReport Report { get; set; } = null!;
}
