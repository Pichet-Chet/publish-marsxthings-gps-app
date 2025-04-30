using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class SysPermission
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public int UserId { get; set; }

    public bool AllowAccess { get; set; }
}
