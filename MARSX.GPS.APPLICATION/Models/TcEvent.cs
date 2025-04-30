using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcEvent
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime Eventtime { get; set; }

    public int? Deviceid { get; set; }

    public int? Positionid { get; set; }

    public int? Geofenceid { get; set; }

    public string? Attributes { get; set; }

    public int? Maintenanceid { get; set; }

    public virtual TcDevice? Device { get; set; }
}
