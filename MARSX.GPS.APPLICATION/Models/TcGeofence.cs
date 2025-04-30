using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcGeofence
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Area { get; set; } = null!;

    public string? Attributes { get; set; }

    public int? Calendarid { get; set; }

    public virtual TcCalendar? Calendar { get; set; }
}
