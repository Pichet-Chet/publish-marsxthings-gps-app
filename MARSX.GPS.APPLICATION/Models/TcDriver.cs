using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcDriver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Uniqueid { get; set; } = null!;

    public string Attributes { get; set; } = null!;
}
