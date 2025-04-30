using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserMaintenance
{
    public int Userid { get; set; }

    public int Maintenanceid { get; set; }

    public virtual TcMaintenance Maintenance { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
