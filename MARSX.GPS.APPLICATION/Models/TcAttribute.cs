using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcAttribute
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Attribute { get; set; } = null!;

    public string Expression { get; set; } = null!;
}
