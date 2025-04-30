using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserAttribute
{
    public int Userid { get; set; }

    public int Attributeid { get; set; }

    public virtual TcAttribute Attribute { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
