using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class Lock
{
    public string Resource { get; set; } = null!;

    public int Updatecount { get; set; }

    public DateTime? Acquired { get; set; }
}
