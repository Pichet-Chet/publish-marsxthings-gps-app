using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcGroupAttribute
{
    public int Groupid { get; set; }

    public int Attributeid { get; set; }

    public virtual TcAttribute Attribute { get; set; } = null!;

    public virtual TcGroup Group { get; set; } = null!;
}
