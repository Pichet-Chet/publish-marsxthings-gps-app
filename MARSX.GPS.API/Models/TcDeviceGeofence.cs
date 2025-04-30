using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcDeviceGeofence
{
    public int Deviceid { get; set; }

    public int Geofenceid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcGeofence Geofence { get; set; } = null!;
}
