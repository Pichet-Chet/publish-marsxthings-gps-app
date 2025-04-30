using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class MasterThaiSubdistrict
{
    public int? Id { get; set; }

    public int? ZipCode { get; set; }

    public string? NameTh { get; set; }

    public string? NameEn { get; set; }

    public int? DistrictsId { get; set; }

    public string? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public string? DeletedAt { get; set; }
}
