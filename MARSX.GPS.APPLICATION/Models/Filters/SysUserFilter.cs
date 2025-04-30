using System;
namespace MARSX.GPS.APPLICATION.Models.Filters
{
    public class SysUserFilter : GlobalFilter
	{
        public string? UserName { get; set; }

        public string? FirstNameEn { get; set; }

        public string? LastNameEn { get; set; }

        public string? FirstNameTh { get; set; }

        public string? LastNameTh { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }
       
        public bool? IsActive { get; set; }

    }
}

