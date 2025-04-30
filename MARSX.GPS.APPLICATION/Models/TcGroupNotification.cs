using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcGroupNotification
{
    public int Groupid { get; set; }

    public int Notificationid { get; set; }

    public virtual TcGroup Group { get; set; } = null!;

    public virtual TcNotification Notification { get; set; } = null!;
}
