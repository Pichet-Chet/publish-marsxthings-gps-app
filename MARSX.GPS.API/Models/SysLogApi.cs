using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class SysLogApi
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? ControllerName { get; set; }

    public string? MethodName { get; set; }

    public string? ServiceName { get; set; }

    public string? EstimateTime { get; set; }

    public string? UnitOfTime { get; set; }

    public DateTime? ServerDatetime { get; set; }
}
