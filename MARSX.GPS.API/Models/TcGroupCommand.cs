using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcGroupCommand
{
    public int Groupid { get; set; }

    public int Commandid { get; set; }

    public virtual TcCommand Command { get; set; } = null!;

    public virtual TcGroup Group { get; set; } = null!;
}
