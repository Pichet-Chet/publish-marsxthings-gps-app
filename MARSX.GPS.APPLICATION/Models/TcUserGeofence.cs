using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcUserGeofence
{
    public int Userid { get; set; }

    public int Geofenceid { get; set; }

    public virtual TcGeofence Geofence { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
