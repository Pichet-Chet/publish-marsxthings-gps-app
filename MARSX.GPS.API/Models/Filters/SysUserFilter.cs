using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class SysUserFilter : GlobalFilter
	{
        public string? UserName { get; set; }

        public string? Password { get; set; } = null!;

        public string? FirstNameEn { get; set; }

        public string? LastNameEn { get; set; }

        public string? FirstNameTh { get; set; }

        public string? LastNameTh { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }
       
        public bool? IsActive { get; set; }

        public int? PassCode { get; set; }

    }
}

