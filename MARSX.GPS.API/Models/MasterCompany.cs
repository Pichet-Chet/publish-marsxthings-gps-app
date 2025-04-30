using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class MasterCompany
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? NameTh { get; set; }

    public string? Description { get; set; }

    public string? AddressEn { get; set; }

    public string? AddressTh { get; set; }

    public int? CountryId { get; set; }

    public int? ProvinceId { get; set; }

    public int? DistrictId { get; set; }

    public string? SubDistrictId { get; set; }

    public int? ZipCode { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ContactTel { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }
}
