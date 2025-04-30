using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserOrder
{
    public int Userid { get; set; }

    public int Orderid { get; set; }

    public virtual TcOrder Order { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
