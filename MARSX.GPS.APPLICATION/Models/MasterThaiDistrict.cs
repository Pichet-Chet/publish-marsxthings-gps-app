using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class MasterThaiDistrict
{
    public int? Id { get; set; }

    public string? NameTh { get; set; }

    public string? NameEn { get; set; }

    public int? ProvinceId { get; set; }

    public string? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public string? DeletedAt { get; set; }
}
