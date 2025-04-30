using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class SysPermissionGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public bool AllowAccess { get; set; }
}
