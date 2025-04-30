using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class SysMenu
{
    public int Id { get; set; }

    public int? SysApplicationId { get; set; }

    public string? MenuCode { get; set; }

    public string? MenuName { get; set; }

    public string? MenuGroup { get; set; }

    public string? MenuDesription { get; set; }

    public int? MenuSequence { get; set; }

    public string? MenuGroupName { get; set; }

    public string? MenuGroupSeq { get; set; }

    public string? MenuGroupIcon { get; set; }

    public string? MenuIcon { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public bool? IsActive { get; set; }
}
