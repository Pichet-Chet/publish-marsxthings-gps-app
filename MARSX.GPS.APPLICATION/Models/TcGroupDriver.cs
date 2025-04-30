using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcGroupDriver
{
    public int Groupid { get; set; }

    public int Driverid { get; set; }

    public virtual TcDriver Driver { get; set; } = null!;

    public virtual TcGroup Group { get; set; } = null!;
}
