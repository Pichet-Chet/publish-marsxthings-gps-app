using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserNotification
{
    public int Userid { get; set; }

    public int Notificationid { get; set; }

    public virtual TcNotification Notification { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
