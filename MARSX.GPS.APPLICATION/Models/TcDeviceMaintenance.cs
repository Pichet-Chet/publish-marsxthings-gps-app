using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDeviceMaintenance
{
    public int Deviceid { get; set; }

    public int Maintenanceid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcMaintenance Maintenance { get; set; } = null!;
}
