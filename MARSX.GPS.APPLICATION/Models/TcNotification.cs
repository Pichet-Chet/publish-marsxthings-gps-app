using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcNotification
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Attributes { get; set; }

    public bool Always { get; set; }

    public int? Calendarid { get; set; }

    public string? Notificators { get; set; }

    public int? Commandid { get; set; }

    public virtual TcCalendar? Calendar { get; set; }

    public virtual TcCommand? Command { get; set; }
}
