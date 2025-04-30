using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcKeystore
{
    public int Id { get; set; }

    public byte[] Publickey { get; set; } = null!;

    public byte[] Privatekey { get; set; } = null!;
}
