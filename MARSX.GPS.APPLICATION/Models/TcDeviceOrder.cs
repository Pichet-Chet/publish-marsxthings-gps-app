using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDeviceOrder
{
    public int Deviceid { get; set; }

    public int Orderid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcOrder Order { get; set; } = null!;
}
