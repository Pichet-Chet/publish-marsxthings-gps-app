using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserCalendar
{
    public int Userid { get; set; }

    public int Calendarid { get; set; }

    public virtual TcCalendar Calendar { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
