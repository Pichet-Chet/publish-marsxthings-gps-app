using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcGroupMaintenance
{
    public int Groupid { get; set; }

    public int Maintenanceid { get; set; }

    public virtual TcGroup Group { get; set; } = null!;

    public virtual TcMaintenance Maintenance { get; set; } = null!;
}
