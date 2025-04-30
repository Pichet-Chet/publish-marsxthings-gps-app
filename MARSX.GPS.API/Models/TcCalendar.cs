using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcCalendar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Data { get; set; } = null!;

    public string Attributes { get; set; } = null!;

    public virtual ICollection<TcDevice> TcDevices { get; set; } = new List<TcDevice>();

    public virtual ICollection<TcGeofence> TcGeofences { get; set; } = new List<TcGeofence>();

    public virtual ICollection<TcNotification> TcNotifications { get; set; } = new List<TcNotification>();

    public virtual ICollection<TcReport> TcReports { get; set; } = new List<TcReport>();
}
