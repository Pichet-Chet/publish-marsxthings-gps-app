using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcGroupOrder
{
    public int Groupid { get; set; }

    public int Orderid { get; set; }

    public virtual TcGroup Group { get; set; } = null!;

    public virtual TcOrder Order { get; set; } = null!;
}
