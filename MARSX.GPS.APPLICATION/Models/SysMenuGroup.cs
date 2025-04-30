using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class SysMenuGroup
{
    public int Id { get; set; }

    public int SysPermissionGroupId { get; set; }

    public int SysMenuId { get; set; }

    public bool AllowAccess { get; set; }
}
