using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserDevice
{
    public int Userid { get; set; }

    public int Deviceid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
