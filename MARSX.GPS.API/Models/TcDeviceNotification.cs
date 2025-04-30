using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcDeviceNotification
{
    public int Deviceid { get; set; }

    public int Notificationid { get; set; }

    public virtual TcDevice Device { get; set; } = null!;

    public virtual TcNotification Notification { get; set; } = null!;
}
