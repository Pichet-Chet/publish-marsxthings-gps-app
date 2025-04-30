using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDevice
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Uniqueid { get; set; } = null!;

    public DateTime? Lastupdate { get; set; }

    public int? Positionid { get; set; }

    public int? Groupid { get; set; }

    public string? Attributes { get; set; }

    public string? Phone { get; set; }

    public string? Model { get; set; }

    public string? Contact { get; set; }

    public string? Category { get; set; }

    public bool? Disabled { get; set; }

    public string? Status { get; set; }

    public DateTime? Expirationtime { get; set; }

    public bool? Motionstate { get; set; }

    public DateTime? Motiontime { get; set; }

    public double? Motiondistance { get; set; }

    public bool? Overspeedstate { get; set; }

    public DateTime? Overspeedtime { get; set; }

    public int? Overspeedgeofenceid { get; set; }

    public bool? Motionstreak { get; set; }

    public int? Calendarid { get; set; }

    public virtual TcCalendar? Calendar { get; set; }

    public virtual TcGroup? Group { get; set; }

    public virtual ICollection<TcCommandsQueue> TcCommandsQueues { get; set; } = new List<TcCommandsQueue>();

    public virtual ICollection<TcEvent> TcEvents { get; set; } = new List<TcEvent>();

    public virtual ICollection<TcPosition> TcPositions { get; set; } = new List<TcPosition>();
}
