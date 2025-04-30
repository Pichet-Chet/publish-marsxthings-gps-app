using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcGroupGeofence
{
    public int Groupid { get; set; }

    public int Geofenceid { get; set; }

    public virtual TcGeofence Geofence { get; set; } = null!;

    public virtual TcGroup Group { get; set; } = null!;
}
