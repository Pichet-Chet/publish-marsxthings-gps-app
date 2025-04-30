using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDeviceAttribute
{
    public int Deviceid { get; set; }

    public int Attributeid { get; set; }

    public virtual TcAttribute Attribute { get; set; } = null!;

    public virtual TcDevice Device { get; set; } = null!;
}
