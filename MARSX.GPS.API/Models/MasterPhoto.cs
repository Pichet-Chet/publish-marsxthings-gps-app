using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class MasterPhoto
{
    public int Id { get; set; }

    public string? Categery { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Size { get; set; }

    public string? SizeUnit { get; set; }

    public string? Location { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public int? MasterDeviceId { get; set; }

    public string? Label { get; set; }
}
