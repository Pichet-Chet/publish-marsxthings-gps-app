using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class MasterThaiProvince
{
    public int? Id { get; set; }

    public string? NameTh { get; set; }

    public string? NameEn { get; set; }

    public int? GeographyId { get; set; }

    public string? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public string? DeletedAt { get; set; }
}
