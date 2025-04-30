using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcUserCommand
{
    public int Userid { get; set; }

    public int Commandid { get; set; }

    public virtual TcCommand Command { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
