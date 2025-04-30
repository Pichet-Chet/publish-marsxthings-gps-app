using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcCommand
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool Textchannel { get; set; }

    public string Attributes { get; set; } = null!;

    public virtual ICollection<TcNotification> TcNotifications { get; set; } = new List<TcNotification>();
}
