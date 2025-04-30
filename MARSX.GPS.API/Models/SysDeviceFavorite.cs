using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class SysDeviceFavorite
{
    public int Id { get; set; }

    public int? DeviceId { get; set; }

    public string? UserName { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
