using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class SysUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FirstNameEn { get; set; }

    public string? LastNameEn { get; set; }

    public string? FirstNameTh { get; set; }

    public string? LastNameTh { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    /// <summary>
    /// CURRENT_TIMESTAMP
    /// </summary>
    public DateTime? UpdateDate { get; set; }

    public bool? IsActive { get; set; }

    public int? PassCode { get; set; }

    public int? MasterCompanyId { get; set; }

    public int? MasterDepartmentId { get; set; }

    public int? MasterPositionId { get; set; }

    public string? PrefixNameTh { get; set; }

    public string? PrefixNameEn { get; set; }
}
