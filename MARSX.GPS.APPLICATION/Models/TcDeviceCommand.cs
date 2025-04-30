using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDeviceCommand
{
    public int Deviceid { get; set; }

    public int Commandid { get; set; }

    public virtual TcCommand Command { get; set; } = null!;

    public virtual TcDevice Device { get; set; } = null!;
}
