using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcDeviceDriver
{
    public int Deviceid { get; set; }

    public int Driverid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcDriver Driver { get; set; } = null!;
}
