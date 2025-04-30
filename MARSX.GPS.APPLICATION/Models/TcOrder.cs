using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcOrder
{
    public int Id { get; set; }

    public string Uniqueid { get; set; } = null!;

    public string? Description { get; set; }

    public string? Fromaddress { get; set; }

    public string? Toaddress { get; set; }

    public string Attributes { get; set; } = null!;
}
