using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcUserGroup
{
    public int Userid { get; set; }

    public int Groupid { get; set; }

    public virtual TcGroup Group { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
