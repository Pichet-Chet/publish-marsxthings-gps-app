using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcReport
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Calendarid { get; set; }

    public string Attributes { get; set; } = null!;

    public virtual TcCalendar Calendar { get; set; } = null!;
}
