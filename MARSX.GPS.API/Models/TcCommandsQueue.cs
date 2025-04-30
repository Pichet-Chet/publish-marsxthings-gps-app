using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcCommandsQueue
{
    public int Id { get; set; }

    public int Deviceid { get; set; }

    public string Type { get; set; } = null!;

    public bool Textchannel { get; set; }

    public string Attributes { get; set; } = null!;

    public virtual TcDevice Device { get; set; } = null!;
}
