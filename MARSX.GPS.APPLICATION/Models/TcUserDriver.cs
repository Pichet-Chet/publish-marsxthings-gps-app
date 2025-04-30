using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcUserDriver
{
    public int Userid { get; set; }

    public int Driverid { get; set; }

    public virtual TcDriver Driver { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
