using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class MasterDeviceCategory
{
    public int Id { get; set; }

    public string? NameEn { get; set; }

    public string? NameTh { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }
}
